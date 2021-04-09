using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using TESTECAPI.DTO;
using TESTECAPI.Request;
using TESTECAPI.Response;


namespace TESTECAPI.Controllers
{
    public class EnderecoController : BaseController
    {
        private TESTECAPIEntities db = new TESTECAPIEntities();

        [System.Web.Http.HttpPost]

        public IHttpActionResult CadastrarEndereco(CadastrarEnderecoRequest request)
        {
            CadastrarEnderecoResponse response = new CadastrarEnderecoResponse();

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                TB_Endereco End = new TB_Endereco
                {
                    Numero = request.Numero,
                    Complemento = request.Complemento,
                    Bairro = request.Bairro,
                    Municipio = request.Municipio,
                    CEP = request.CEP,
                    IdCliente = request.IdCliente,
                    PontoReferencia = request.PontoReferencia,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Estado = request.Estado,
                    Removido = false
                };

                db.TB_Endereco.Add(End);
                db.SaveChanges();

                response.Sucesso = true;
                response.IdEndereco = End.IdEndereco;
                response.Erro = "Consulta executada sem erros.";
            }
            catch (Exception Error)
            {
                response.Erro = Error.Message;
            }

            return CreatedAtRoute("DefaultApi", new { }, response);
        }

        [System.Web.Http.HttpPost] 
        public IHttpActionResult ObterEnderecosDoClienteX(EnderecoDoClienteRequest request)
        {
            EnderecoDoClienteResponse response = new EnderecoDoClienteResponse();

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                //lista da resposta de tipo perfil dto
                List<EnderecoDTO> ListaDeRespostas = new List<EnderecoDTO>();

                //lista de perfis que vem do banco 
                var ListaDeEnderecosDataBase = db.TB_Endereco.Where(w => w.IdCliente == request.IdCliente && w.Removido == false).ToList();

                foreach (var item in ListaDeEnderecosDataBase)
                {
                    EnderecoDTO CadaEndereco = new EnderecoDTO
                    {
                        IdCliente = (int)item.IdCliente, 
                        Bairro = item.Bairro,
                        CEP = item.CEP,
                        Complemento = item.Complemento,
                        Estado = item.Estado,
                        IdEndereco = item.IdEndereco,
                        Latiude = item.Latitude,
                        Longitude = item.Longitude,
                        Municipio = item.Municipio,
                        Numero = (int)item.Numero,
                        PontoReferencia = item.PontoReferencia
                    };
                    ListaDeRespostas.Add(CadaEndereco);
                }

                response.Enderecos = ListaDeRespostas;
                response.Sucesso = true;
                response.Erro = "Consulta executada sem erros.";
            }
            catch (Exception Error)
            {
                response.Erro = Error.Message;
            }
            return CreatedAtRoute("DefaultApi", new { }, response);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult AtualizarEnderecoX(AtualizarEnderecoXRequest request)
        {
            BaseResponse response = new BaseResponse();

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                var EnderecoNoDatabase = db.TB_Endereco.Where(End => End.IdEndereco == request.IdEndereco && End.Removido == false).FirstOrDefault();

                if (EnderecoNoDatabase != null) 
                {                    
                    EnderecoNoDatabase.Bairro = request.Bairro;
                    EnderecoNoDatabase.CEP = request.CEP;
                    EnderecoNoDatabase.Complemento = request.Complemento;
                    EnderecoNoDatabase.Estado = request.Estado;
                    EnderecoNoDatabase.Latitude = request.Latitude;
                    EnderecoNoDatabase.Longitude = request.Longitude;
                    EnderecoNoDatabase.Municipio= request.Municipio;
                    EnderecoNoDatabase.Numero= request.Numero;
                    EnderecoNoDatabase.PontoReferencia= request.PontoReferencia;
                    db.SaveChanges();

                    response.Sucesso = true;
                    response.Erro = "Consulta executada sem erros.";
                }                
            }
            catch (Exception Error)
            {
                response.Erro = Error.Message;
            }

            return CreatedAtRoute("DefaultApi", new { }, response);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult RemoverEnderecoXDoClienteX(RemoverEnderecoXDoClienteX request)
        {
            BaseResponse response = new BaseResponse();

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                var EnderecoNoDatabase = db.TB_Endereco.Where(End => End.IdEndereco == request.IdEndereco && End.IdCliente == request.IdCliente).FirstOrDefault();

                if (EnderecoNoDatabase != null)
                {
                    EnderecoNoDatabase.Removido = request.Removido;
                    db.SaveChanges();

                    response.Sucesso = true;
                    response.Erro = "Consulta executada sem erros.";
                }
            }
            catch (Exception Error)
            {
                response.Erro = Error.Message;
            }

            return CreatedAtRoute("DefaultApi", new { }, response);
        }


    }
}

