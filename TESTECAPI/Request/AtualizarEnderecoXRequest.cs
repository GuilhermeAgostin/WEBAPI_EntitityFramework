using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TESTECAPI.Request
{
    public class AtualizarEnderecoXRequest
    {
        public int IdEndereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string CEP { get; set; }
        public string PontoReferencia { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Estado { get; set; }
    }
}