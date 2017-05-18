using Cedro.Restaurante.Dominio;
using Cedro.Restaurante.Repositorios.Comum;
using Cedro.Restaurante.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cedro.Restaurante.Service.Controllers
{
    public class GenericoController : ApiController
    {
        private IRepositoriosGenerico<Dominio.RestauranteObj, int> _repositorioRestaurante;

        private IRepositoriosGenerico<PratoObj, int> _repositorioPrato;

        protected IRepositoriosGenerico<Dominio.RestauranteObj, int> RepositorioRestaurante
        {
            get
            {
                if (_repositorioRestaurante == null)
                {
                    _repositorioRestaurante = new RepositorioGenericoEntity<Dominio.RestauranteObj, int>();
                }

                return _repositorioRestaurante;
            }
        }

        protected IRepositoriosGenerico<PratoObj, int> RepositorioPratos
        {
            get
            {
                if (_repositorioPrato == null)
                {
                    _repositorioPrato = new RepositorioGenericoEntity<PratoObj, int>();
                }

                return _repositorioPrato;
            }
        }
    }
}
