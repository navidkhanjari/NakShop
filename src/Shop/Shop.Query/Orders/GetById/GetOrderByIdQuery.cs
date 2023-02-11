using Common.Query;
using Shop.Query.Orders.DTOs;
using System;

namespace Shop.Query.Orders.GetById
{
    public record GetOrderByIdQuery(Guid OrderId) : IBaseQuery<OrderDto?>; }
