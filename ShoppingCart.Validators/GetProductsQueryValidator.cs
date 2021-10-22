using FluentValidation;
using ShoppingCart.Application.Query; 

namespace ShoppingCart.Validators
{
    public class GetProductsQueryValidator : BaseAbstractValidator<GetProductsQuery>
    {
        public GetProductsQueryValidator()
        {
            this.RuleFor(x => x.Take).GreaterThan(0); 
        }
    }
}
