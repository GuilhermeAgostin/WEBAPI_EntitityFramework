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
    public class ClienteController : BaseController
    {
        private TESTECAPIEntities db = new TESTECAPIEntities();

        [System.Web.Http.HttpPost]
        public IHttpActionResult CadastrarCliente(CadastrarClienteRequest request)
        {
            CadastrarClienteResponse response = new CadastrarClienteResponse();

            if (!ModelState.IsValid) { return BadRequest(ModelState); } 

            try
            {
                TB_Cliente cli = new TB_Cliente();

                cli.CPF = request.CPF;
                cli.DataCadastro = request.DataCadastro;
                cli.DataNasc = request.DataNasc;
                cli.Email = request.Email;
                cli.IdPerfil = request.IdPerfil;
                cli.Nome = request.Nome;
                cli.Sexo = request.Sexo;
                cli.Telefone = request.Telefone;
                cli.Removido = false;
                cli.UltimaAtualizacao = null;

                db.TB_Cliente.Add(cli);
                db.SaveChanges();

                response.Sucesso = true;
                response.IdCliente = cli.IdCliente;
                response.Erro = "Consulta executada sem erros.";
            }
            catch (Exception Error)
            {
                response.Erro = Error.Message;
            }
            return CreatedAtRoute("DefaultApi", new { }, response);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult ListarClientes()
        {
            ListarClientesResponse response = new ListarClientesResponse();

            try
            {
                //lista da resposta de tipo perfil dto
                List<ClienteDTO> ListaDeRespostas = new List<ClienteDTO>();

                //lista de perfis que vem do banco 
                var ListaDeClientesDataBase = db.TB_Cliente.Where(W => W.Removido == false).ToList();

                foreach (var item in ListaDeClientesDataBase)
                {
                    ClienteDTO CadaCliente = new ClienteDTO
                    {
                        IdCliente = item.IdCliente,
                        CPF = item.CPF,
                        DataCadastro = item.DataCadastro,
                        DataNasc = item.DataNasc,
                        Email = item.Email,
                        IdPerfil = (int)item.IdPerfil,
                        Nome = item.Nome,
                        Sexo = item.Sexo,
                        Telefone = item.Telefone,
                    };
                    ListaDeRespostas.Add(CadaCliente);
                }

                response.ListaClientes = ListaDeRespostas;
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
        public IHttpActionResult ObterInformacoesDoClienteX(ObterInformacoesDoClienteXRequest request)
        {
            ObterInformacoesDoClienteXResponse response = new ObterInformacoesDoClienteXResponse();

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                var Cliente = db.TB_Cliente.Where(tabela => tabela.IdCliente == request.IdCliente && tabela.Removido == false).FirstOrDefault();
                
                if (Cliente != null)
                {
                    ClienteDTO ClienteASerDevolvido = new ClienteDTO
                    {
                        CPF = Cliente.CPF,
                        DataCadastro = Cliente.DataCadastro,
                        DataNasc = Cliente.DataNasc,
                        Email = Cliente.Email,
                        IdPerfil = (int)Cliente.IdPerfil,
                        Nome = Cliente.Nome,
                        Sexo = Cliente.Sexo,
                        Telefone = Cliente.Telefone
                    };

                    response.Cliente = ClienteASerDevolvido;
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
        public IHttpActionResult AtualizarInfoClienteX(AtualizarInfoClienteX request)
        {
            BaseResponse response = new BaseResponse();

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                var ClienteNoDatabase = db.TB_Cliente.Where(Cli => Cli.IdCliente == request.IdCliente && Cli.Removido ==  false).FirstOrDefault();
                var UltimaAtualizacao = ClienteNoDatabase.UltimaAtualizacao == null ? DateTime.Now : ClienteNoDatabase.UltimaAtualizacao.Value;

                if (ClienteNoDatabase != null)
                {
                    ClienteNoDatabase.CPF = request.CPF;
                    ClienteNoDatabase.DataCadastro = request.DataCadastro;
                    ClienteNoDatabase.DataNasc = request.DataNasc;
                    ClienteNoDatabase.Email = request.Email;
                    ClienteNoDatabase.IdPerfil = request.IdPerfil;
                    ClienteNoDatabase.Nome = request.Nome;
                    ClienteNoDatabase.Sexo = request.Sexo;
                    ClienteNoDatabase.Telefone = request.Telefone;
                    ClienteNoDatabase.UltimaAtualizacao = UltimaAtualizacao;
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
        public IHttpActionResult RemoverClienteX(RemoverClienteXRequest request)
        {
            BaseResponse response = new BaseResponse();

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                var ClienteNoDatabase = db.TB_Cliente.Where(End => End.IdCliente== request.IdCliente).FirstOrDefault();

                if (ClienteNoDatabase != null)
                {
                    ClienteNoDatabase.Removido = request.Removido;
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