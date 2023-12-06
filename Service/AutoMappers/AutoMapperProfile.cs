using AutoMapper;
using BussinessObject.Utils;
using BussinessObject.ViewModels;
using DataAccessObject;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        IUnitOfWork _unitOfWork;

        

        public AutoMapperProfile()
        {
            AutoMapping();
        }

        private void AutoMapping()
        {
            CreateMap<PokemonMoveViewModel, PokemonMove>()
                .ForMember(dest => dest.MoveType, opt => opt.MapFrom(src => ConstantLib.MoveTypes.IndexOf(src.MoveType)))
                .ReverseMap()
                .ForMember(dest => dest.MoveType, opt => opt.MapFrom(src => ConstantLib.MoveTypes[(int)src.MoveType]));

            //CreateMap<PokemonSpecieViewModel, PokemonSpecie>()
            //    .ForMember(dest => dest.MoveType, opt => opt.MapFrom(src => StringLib.MoveTypes.IndexOf(src.MoveType)))
            //    .ReverseMap()
            //    .ForMember(dest => dest.MoveType, opt => opt.MapFrom(src => StringLib.MoveTypes[(int)src.MoveType]));
        }
    }

    
}
