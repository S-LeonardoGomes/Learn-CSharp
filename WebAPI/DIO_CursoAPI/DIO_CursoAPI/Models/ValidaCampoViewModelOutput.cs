using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO_CursoAPI.Models
{
    public class ValidaCampoViewModelOutput
    {
        public IEnumerable<string> Errors { get; private set; }

        public ValidaCampoViewModelOutput(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
