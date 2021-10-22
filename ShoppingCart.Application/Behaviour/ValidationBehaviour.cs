using FluentValidation;
using MediatR;
using ShoppingCart.Common.Exceptions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Behaviour
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationBehaviour(IValidator<TRequest> validator)
        {
            this._validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationResult = await this._validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new InternalValidationException(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var resp = await next(); 
            return resp;
        }
    }
}
