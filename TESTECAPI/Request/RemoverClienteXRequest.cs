using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TESTECAPI.Request
{
    public class RemoverClienteXRequest
    {
        public int IdCliente { get; set; }
        public bool Removido { get; set; }

    }
}