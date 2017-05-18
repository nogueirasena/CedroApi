using AutoMapper;
using Cedro.Restaurante.Dominio;
using Cedro.Restaurante.Service.ViewModels.Pratos;
using Cedro.Restaurante.Service.ViewModels.Restaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cedro.Restaurante.Service.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<RestauranteViewModel, RestauranteObj>();
            Mapper.CreateMap<PratosViewModel, PratoObj>();
        }
    }
}