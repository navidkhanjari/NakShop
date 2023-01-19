using MediatR;

namespace Common.Query.Filters
{
    public interface IBaseQueryFilterHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>

    {

    }

}