using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TESTECAPI.Request
{
    public class AtualizarInfoClienteX
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public int IdPerfil { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataNasc { get; set; }
        public string Sexo { get; set; }
    }
}