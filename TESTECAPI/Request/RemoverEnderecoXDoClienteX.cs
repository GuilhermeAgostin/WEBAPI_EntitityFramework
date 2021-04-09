using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TESTECAPI.Request
{
    public class RemoverEnderecoXDoClienteX
    {
        public int IdEndereco { get; set; }
        public int IdCliente { get; set; }
        public bool Removido { get; set; }

    }
}