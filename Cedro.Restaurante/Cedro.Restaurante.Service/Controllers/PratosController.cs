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
using Cedro.Restaurante.Repositorios.Entity;
using Cedro.Restaurante.Repositorios.Comum;
using AutoMapper;
using Cedro.Restaurante.Service.ViewModels.Pratos;
using Cedro.Restaurante.Repositorios.Comum.Entity;

namespace Cedro.Restaurante.Service.Controllers
{
    public class PratosController : GenericoController
    {
        //private IRepositoriosGenerico<Pratos, int> RepositorioPratos =
        //    new RepositorioGenericoEntity<Pratos, int>();

        //private IRepositoriosGenerico<Restaurantes, int> RepositorioRestaurante =
        //new RepositorioGenericoEntity<Restaurantes,int>();

       

        // GET: api/Pratos
        public List<PratosViewModel> GetPratos()
        {
            return Mapper.Map<List<PratoObj>, List<PratosViewModel>>(RepositorioPratos.Selecionar()).ToList();
        }

        // GET: api/Pratos/5
        [ResponseType(typeof(PratoObj))]
        public IHttpActionResult GetPratos(int id)
        {
            PratoObj pratos = RepositorioPratos.SelectionarPorId(id);


            if (pratos == null)
            {
                return Ok("Prato não encontrado");
            }

            return Ok(Mapper.Map<PratoObj, PratosViewModel>(pratos));
        }

        // PUT: api/Pratos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPratos(PratosViewModel viewModel)
        {
           
            if (ModelState.IsValid)
            {

                Dominio.RestauranteObj restaurante = RepositorioRestaurante.SelectionarPorId(viewModel.IdRestaurante);

                if (restaurante == null)
                {
                    return Ok("Restaurante não encontrado");
                }

                PratoObj pratos = Mapper.Map<PratosViewModel, PratoObj>(viewModel);
                RepositorioPratos.Alterar(pratos);
                return Ok("Prato Alterado com sucesso.");
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // POST: api/Pratos
        [ResponseType(typeof(PratoObj))]
        public IHttpActionResult PostPratos(PratosViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                Dominio.RestauranteObj restaurante = RepositorioRestaurante.SelectionarPorId(viewModel.IdRestaurante);

                if (restaurante == null)
                {
                    return Ok("Restaurante não encontrado");
                }
                PratoObj pratos = Mapper.Map<PratosViewModel, PratoObj>(viewModel);
                RepositorioPratos.Inserir(pratos);

                return CreatedAtRoute("DefaultApi", new { id = pratos.Id }, pratos);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        // DELETE: api/Pratos/5
        [ResponseType(typeof(PratoObj))]
        public IHttpActionResult DeletePratos(int id)
        {
            PratoObj pratos = RepositorioPratos.SelectionarPorId(id);
            if (pratos == null)
            {
                return Ok("Prato não encontrado.");
            }
            else
            {
                RepositorioPratos.ExcluirPorId(id);


                return Ok("Prato Excluido com sucesso.");
            }
        }


    }
}