﻿using Common.Query.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Query
{
    public class BaseFilter
    {
        public int EntityCount { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageCount { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int Take { get; private set; }
        public void GeneratePaging(IQueryable<Object> data, int take, int currentPage)
        {
            var entityCount = data.Count();
            var pageCount = (int)Math.Ceiling(entityCount / (double)take);
            PageCount = pageCount;
            CurrentPage = currentPage;
            EndPage = (currentPage + 5 > pageCount) ? pageCount : currentPage + 5;
            EntityCount = entityCount;
            Take = take;
            StartPage = (currentPage - 4 <= 0) ? 1 : currentPage - 4;
        }
        public void GeneratePaging(int take, int currentPage,int entityCount)
        {
            var pageCount = (int)Math.Ceiling(entityCount / (double)take);
            PageCount = pageCount;
            CurrentPage = currentPage;
            EndPage = (currentPage + 5 > pageCount) ? pageCount : currentPage + 5;
            EntityCount = entityCount;
            Take = take;
            StartPage = (currentPage - 4 <= 0) ? 1 : currentPage - 4;
        }
    }
    public class BaseFilter<TData, TFilterParams>: BaseFilter where TData : class where TFilterParams : BaseFilterParam
    {
        public List<TData> Data { get; set; }
        public TFilterParams Filters { get; set; }
    }
}
