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
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<RestauranteObj, RestauranteViewModel>();

            Mapper.CreateMap<PratoObj, PratosViewModel>()
                .ForMember(p => p.NomeRestaurante, opt =>
                {
                    opt.MapFrom(src =>
                        src.Restaurante.Nome 
                    );
                });

        }
    }
}