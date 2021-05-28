namespace BF.Web.Api
{
    public interface IBaseRequest { }
    public interface IRequest<out TResponse> : IBaseRequest { }

    public struct Unit
    {

    }
}