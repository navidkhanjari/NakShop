using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Events;
using Shop.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        public Guid UserId { get; private set; }
        public string ShopName { get; private set; }
        public SellerStatus Status { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public List<SellerInventory> Inventories { get; private set; }

        private Seller()
        {
        }

        public Seller(Guid userId, string shopName, ISellerDomainService domainService)
        {
            Guard(shopName, userId, domainService);


            UserId = userId;
            ShopName = shopName;

            Status = SellerStatus.Active;
            Inventories = new List<SellerInventory>();
            AddDomainEvent(new SellerCreatedDomainEvent() { UserId = UserId, ShopName = ShopName });
        }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Edit(string shopName, ISellerDomainService domainService)
        {
            Guard(shopName, UserId, domainService);
            ShopName = shopName;
     
        }

        public void AddInventory(SellerInventory inventory, ISellerDomainService domainService)
        {
            if (Inventories.Any(f => f.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException("این محصول قبلا ثبت شده است.");

            if (domainService.ProductNotFound(inventory.ProductId))
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");

            Inventories.Add(inventory);
        }

        public void EditInventory(Guid inventoryId, int count, int price, int discountPercentage)
        {
            var currentInventory = Inventories.FirstOrDefault(f => f.Id == inventoryId);
            if (currentInventory == null)
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");

            //TODO Check Inventories
            currentInventory.Edit(count, price, discountPercentage);
        }

        public void DeleteInventory(Guid inventoryId)
        {
            var currentInventory = Inventories.FirstOrDefault(f => f.Id == inventoryId);
            if (currentInventory == null)
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");

            Inventories.Remove(currentInventory);
        }

        public void Guard(string shopName,Guid userId, ISellerDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));

            if (userId != UserId)
                if (domainService.SellerIsExist(userId))
                    throw new InvalidDomainDataException("این کاربر قبلا به عنوان فروشنده انتخاب شده است");

        }
    }
}
