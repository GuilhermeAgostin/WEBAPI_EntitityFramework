using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TESTECAPI.Response
{
    public class BaseResponse
    {
        public bool Sucesso { get; set; }
        public string Erro { get; set; }
    }
}