using MediatR;

namespace Spinner.Application.Common
{
    internal interface IQuery<T> : IRequest<T> { }
}
