using Common.Application;
using MediatR;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.GetByFIlter;
using Shop.Query.Sellers.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Sellers
{
    internal class SellerFacade : ISellerFacade
    {
        private readonly IMediator _mediator;

        public SellerFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> CreateSeller(CreateSellerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditSeller(EditSellerCommand command)
        {
            return await _mediator.Send(command);

        }
        public async Task<SellerDto?> GetSellerById(Guid sellerId)
        {
            return await _mediator.Send(new GetSellerByIdQuery(sellerId));

        }
        public async Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams)
        {
            return await _mediator.Send(new GetSellerByFilterQuery(filterParams));
        }
    }
}
