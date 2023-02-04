﻿using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Context;
using System;


namespace Shop.Infrastructure.Persistent.Ef.Aggregates.SiteEntities.Repositories
{
    internal class SliderRepository : BaseRepository<Slider>, ISliderRepository
    {
        public SliderRepository(ShopContext context) : base(context)
        {
        }

        public void Delete(Slider slider)
        {
            throw new NotImplementedException();
        }
    }
}
