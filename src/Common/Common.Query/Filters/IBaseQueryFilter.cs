using MediatR;

namespace Common.Query.Filters
{
    public class BaseQueryFilter<TResponse, TFilterParam> : IRequest<TResponse> where TFilterParam : BaseFilterParam
    {
        public BaseQueryFilter(TFilterParam filterParams)
        {
            FilterParams = filterParams;
        }


        public TFilterParam FilterParams { get; private set; }
    }
}