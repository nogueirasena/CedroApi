using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cedro.Restaurante.AcessoDados.Entity.Context;
using Cedro.Restaurante.Dominio;
using Cedro.Restaurante.Service.ViewModels.Restaurante;
using AutoMapper;
using Cedro.Restaurante.Repositorios.Comum;
using Cedro.Restaurante.Repositorios.Entity;
using System.Web.Http.Cors;
using Cedro.Restaurante.Repositorios.Comum.Entity;

namespace Cedro.Restaurante.Service.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RestauranteController : GenericoController
    {
       
        // GET: api/Restaurante

          
        public List<RestauranteViewModel> GetRestaurantes()
        {
            return Mapper.Map<List<RestauranteObj>,List<RestauranteViewModel>>( RepositorioRestaurante.Selecionar()).ToList();
        }

        // GET: api/Restaurante/5
        [ResponseType(typeof(Dominio.RestauranteObj))]
        public IHttpActionResult GetRestaurantes(int id)
        {
            Dominio.RestauranteObj restaurantes = RepositorioRestaurante.SelectionarPorId(id);
            if (restaurantes == null)
            {
                return Ok("Restaurante não encontrado");
            }

            return Ok(Mapper.Map<RestauranteObj, RestauranteViewModel>(restaurantes));
        }

        // PUT: api/Restaurante/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurantes(RestauranteViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var restaurate = Mapper.Map<RestauranteViewModel, RestauranteObj>(viewModel);
                RepositorioRestaurante.Alterar(restaurate);
                return Ok("Restaurante Alterado com sucesso.");
            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        // POST: api/Restaurante
        [ResponseType(typeof(Dominio.RestauranteObj))]
        public IHttpActionResult PostRestaurantes(RestauranteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var restaurate = Mapper.Map<RestauranteViewModel, RestauranteObj>(viewModel);
                RepositorioRestaurante.Inserir(restaurate);

                return CreatedAtRoute("DefaultApi", new { id = restaurate.Id }, restaurate);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // DELETE: api/Restaurante/5
        [ResponseType(typeof(Dominio.RestauranteObj))]
        public IHttpActionResult DeleteRestaurantes(int id)
        {
            Dominio.RestauranteObj restaurantes = RepositorioRestaurante.SelectionarPorId(id);

           
            if (restaurantes == null)
            {
                return Ok("Restaurante não encontrado.");
            }
            else
            {
                //List<Pratos> pratos = RepositorioPratos.Selecionar().Where(p => p.IdRestaurante == id).ToList();
                //RepositorioPratos.ExcluiDependentes(pratos);
                RepositorioRestaurante.ExcluirPorId(id);
                return Ok("Restaurante Excluido com sucesso.");
            }

        }
    }
}