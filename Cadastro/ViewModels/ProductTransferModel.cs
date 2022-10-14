using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.ViewModels
{
    public class ProductTransferModel
    {
        public ProductViewModel Product{ get; set; }

        public IEnumerable<ClientViewModel> Clients { get; set; }
    }
}
