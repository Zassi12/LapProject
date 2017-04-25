using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAP.Logic;
using System.Linq.Expressions;
using LAP.Web.Models;

namespace LAP.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper CommonMapper;
        public static IMapper InnovationMapper;
        public static IMapper StartupMapper;
        public static void RegisterMappings()
        {
            var commonConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<CommonProfile>());
            var innovationMapper = new MapperConfiguration(cfg => cfg.AddProfile<InnovationProfile>());
            var startupMapper = new MapperConfiguration(cfg => cfg.AddProfile<StartupProfile>());

            CommonMapper = commonConfiguration.CreateMapper();
            InnovationMapper = innovationMapper.CreateMapper();
            StartupMapper = startupMapper.CreateMapper();
        }
    }

    public class CommonProfile : Profile
    {
        protected void Configure()
        {
            //base.CreateMap<portaluser, ProfileDataModel>();
            base.CreateMap<companies, FirmenModel>();
            base.CreateMap<facilities, FacilitiesModel>();
            //base.CreateMap<Facility, FacilityModel>();
            //base.CreateMap<RoomFacility, RoomFacilityModel>();
            //base.CreateMap<data.Type, TypeModel>();
            //base.CreateMap<Room, SearchResultModel>();
        }
    }

    public class InnovationProfile : Profile
    {
        protected void Configure()
        {
            //base.CreateMap<User, EmployeeDataModel>();
        }
    }

    public class StartupProfile : Profile
    {
        protected void Configure()
        {

        }
    }


    public static class AutoMapperExtension
    {
        /// extension method for easy use of ignore syntax
        //Mapper.CreateMap<JsonRecord, DatabaseRecord>()
        //.Ignore(record => record.Field)
        //.Ignore(record => record.AnotherField)
        //.Ignore(record => record.Etc);
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(this IMappingExpression<TSource, TDestination> map, Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }
    }


}