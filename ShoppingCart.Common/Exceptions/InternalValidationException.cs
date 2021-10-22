using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Common.Exceptions
{
    public class InternalValidationException : Exception
    {
        public InternalValidationException(List<string> errors)
        {
            Errors = errors;
        }

        public List<string> Errors { get; }
    }
}
