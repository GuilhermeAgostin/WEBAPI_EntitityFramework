using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TESTECAPI.DTO;


namespace TESTECAPI.Response
{
    public class ListarClientesResponse : BaseResponse
    {
        public List<ClienteDTO> ListaClientes { get; set; }
    }
}


