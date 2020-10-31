using MediatR;

namespace Spinner.Application.Common
{
    internal interface ICommand<T> : IRequest<T> { }
}
