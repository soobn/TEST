using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Web.Api
{
    public interface IRequestHandler<in TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {

        Task<TResponse> Handle(TRequest request);
    }

    public interface IRequestHandler<in TRequest> : IRequestHandler<TRequest, Unit>
        where TRequest : IRequest<Unit>
    {
    }

}
