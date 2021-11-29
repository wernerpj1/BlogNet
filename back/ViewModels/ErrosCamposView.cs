using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.ViewModels
{
    public class ErrosCamposView
    {
        public IEnumerable<string> Erros { get; set; }

        public ErrosCamposView(IEnumerable<string> errors)
        {
            Erros = errors;
        }
    }
}