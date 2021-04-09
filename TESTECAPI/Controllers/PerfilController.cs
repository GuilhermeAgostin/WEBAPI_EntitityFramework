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
    public class PerfilController : BaseController
    {
        private TESTECAPIEntities db = new TESTECAPIEntities();

        [System.Web.Http.HttpPost]
        public IHttpActionResult CadastrarPerfil(CadastrarPerfilRequest request)
        {
            CadastrarPerfilResponse response = new CadastrarPerfilResponse();

            try
            {
                TB_Perfil Perf = new TB_Perfil();

                Perf.Nome = request.Nome;

                db.TB_Perfil.Add(Perf);
                db.SaveChanges();

                response.Sucesso = true;
                response.IdPerfil = Perf.IdPerfil;
                response.Erro = "Consulta executada sem erros.";
            }
            catch (Exception Error)
            {
                response.Erro = Error.Message;
            }
            return CreatedAtRoute("DefaultApi", new { }, response);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult ObterTiposDePerfil()
        {
            ObterTiposDePerfilResponse response = new ObterTiposDePerfilResponse();

            try
            {
                List<PerfilDTO> ListaDeRespostas = new List<PerfilDTO>();

                var ListaDePerfisDataBase = db.TB_Perfil.Where(Perf => Perf.Removido == false).ToList();

                foreach (var item in ListaDePerfisDataBase)
                {
                    PerfilDTO CadaPerfil = new PerfilDTO
                    {
                        IdPerfil = item.IdPerfil,
                        Nome = item.Nome
                    };
                    ListaDeRespostas.Add(CadaPerfil);
                }

                response.TiposDePerfil = ListaDeRespostas;
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

        public IHttpActionResult AtualizarNomePerfil(AtualizarNomePerfilRequest request)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                var PerfilNoDatabase = db.TB_Perfil.Where(Perf => Perf.IdPerfil == request.IdPerfil && Perf.Removido == false).FirstOrDefault();

                if (PerfilNoDatabase != null)
                {
                    PerfilNoDatabase.Nome = request.Nome;
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
        public IHttpActionResult RemoverPerfilX(RemoverPerfilXRequest request)
        {
            BaseResponse response = new BaseResponse();

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                var PerfilNoDatabase = db.TB_Perfil.Where(End => End.IdPerfil== request.IdPerfil).FirstOrDefault();

                if (PerfilNoDatabase != null)
                {
                    PerfilNoDatabase.Removido = request.Removido;
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