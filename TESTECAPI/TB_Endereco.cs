//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TESTECAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_Endereco
    {
        public int IdEndereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string CEP { get; set; }
        public int IdCliente { get; set; }
        public string PontoReferencia { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Estado { get; set; }
        public bool Removido { get; set; }
    
        public virtual TB_Cliente TB_Cliente { get; set; }
    }
}
