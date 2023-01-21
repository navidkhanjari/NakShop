using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Events;
using Shop.Domain.OrderAgg.Services;
using Shop.Domain.OrderAgg.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    public class Order:AggregateRoot
    {
        private Order()
        {
        }
        public Order(Guid userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }
        public Guid UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public OrderDiscount? Discount { get; private set; }
        public OrderAddress? Address { get; private set; }
        public OrderDeliveryInfo? OrderDeliveryInfo { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public DateTime? FinallyDate { get; private set; }
        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(f => f.TotalPrice);

                totalPrice += OrderDeliveryInfo?.ShippingCost ?? 0;
                totalPrice -= Discount?.DiscountAmount ?? 0;

                return totalPrice;
            }
        }

        public int ItemCount => Items.Count;

        //public bool SyncOrderWithInventory(IOrderDomainService domainService)
        //{
        //    if (Status != OrderStatus.Pending)
        //        throw new InvalidDomainDataException();
        //    bool isChanged = false;

        //    for (int i = Items.Count - 1; i >= 0; i--)
        //    {
        //        var item = Items[i];
        //        var inventory = domainService.GetInventory(item.InventoryId);
        //        if (item.Price != inventory.Price || item.DiscountPercentage != inventory.DiscountPercentage)
        //        {
        //            item.ChangePrice(inventory.Price, inventory.DiscountPercentage);
        //            isChanged = true;
        //        }
        //        if (inventory.Count == 0)
        //        {
        //            Items.RemoveAt(i);
        //            isChanged = true;
        //            continue;
        //        }

        //        if (item.Count > inventory.Count)
        //        {
        //            item.ChangeCount(inventory.Count);
        //            isChanged = true;
        //        }
        //    }

        //    return isChanged;
        //}
        public void AddItem(OrderItem item, IOrderDomainService domainService)
        {
            ChangeOrderGuard();

            var oldItem = Items.FirstOrDefault(f => f.InventoryId == item.InventoryId);
            if (oldItem != null)
            {
                var newCount = item.Count + oldItem.Count;
                CheckInventoryCountGuard(domainService, item.InventoryId, newCount);
                oldItem.ChangeCount(newCount);
                return;
            }
            CheckInventoryCountGuard(domainService, item.InventoryId, item.Count);
            Items.Add(item);
        }

        public void RemoveItem(Guid itemId)
        {
            ChangeOrderGuard();

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem != null)
                Items.Remove(currentItem);
        }

        public void IncreaseItemCount(Guid itemId, int count, IOrderDomainService domainService)
        {
            ChangeOrderGuard();

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();

            CheckInventoryCountGuard(domainService, currentItem.InventoryId, currentItem.Count + count);
            currentItem.IncreaseCount(count);
        }

        public void DecreaseItemCount(Guid itemId, int count)
        {
            ChangeOrderGuard();

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();

            currentItem.DecreaseCount(count);
        }

        public void FinallyOrder()
        {
            if (Status != OrderStatus.Pending)
                return;

            Status = OrderStatus.Finally;
            FinallyDate = DateTime.Now;
            AddDomainEvent(new OrderFinalizedDomainEvent()
            {
                FinallyDate = (DateTime)FinallyDate,
                OrderId = Id
            });
        }

        public void SendOrder(string trackingCode)
        {
            if (Status != OrderStatus.Finally)
                return;

            Status = OrderStatus.Shipping;
            LastUpdate = DateTime.Now;
            OrderDeliveryInfo = OrderDeliveryInfo.SetTrackingCode(trackingCode);
        }

        public void ReceiveOrder()
        {
            if (Status != OrderStatus.Shipping)
                return;
            Status = OrderStatus.Received;
            LastUpdate = DateTime.Now;
            AddDomainEvent(new OrderReceivedDomainEvent(Id, (DateTime)LastUpdate));
        }
        public void Checkout(OrderAddress orderAddress, OrderDeliveryInfo deliveryInfo)
        {
            ChangeOrderGuard();

            OrderDeliveryInfo = deliveryInfo;
            Address = orderAddress;
        }

        private void ChangeOrderGuard()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidDomainDataException("امکان ویرایش این سفارش وجود ندارد");
        }
        private void CheckInventoryCountGuard(IOrderDomainService domainService, Guid inventoryId, int count)
        {
            if (domainService.InventoryIsLessThan(inventoryId, count))
                throw new InvalidDomainDataException("تعداد موجودی فروشنده کمتر از تعداد درخواستی می باشد");
        }
    }
}
