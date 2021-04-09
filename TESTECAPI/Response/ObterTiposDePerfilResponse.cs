using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TESTECAPI.DTO;

namespace TESTECAPI.Response
{
    public class ObterTiposDePerfilResponse : BaseResponse
    {
        public List<PerfilDTO> TiposDePerfil { get; set; }
        
    }
}