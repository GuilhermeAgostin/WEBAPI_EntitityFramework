using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TESTECAPI.DTO;

namespace TESTECAPI.Response
{
    public class EnderecoDoClienteResponse : BaseResponse
    {
        public List<EnderecoDTO> Enderecos { get; set; }
    }
}
