using Common.Query;
using Shop.Query.SiteEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Query.SiteEntities.Sliders.GetById
{
    public record GetSliderByIdQuery(Guid SliderId) : IBaseQuery<SliderDto>;
}
