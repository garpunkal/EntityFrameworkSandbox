using System;
using AutoMapper;

namespace garpunkal.EntityFrameworkSandbox.Web.AutoMapper
{
    public abstract class BaseProfile : Profile
    {
        protected BaseProfile(string profileName)
        {
            ProfileName = profileName;
        }

        public override string ProfileName { get; }

        protected override void Configure()
        {
            CreateMap<string, long>().ConvertUsing(AutoMapperTypeConverters.ConvertToInt64);
            CreateMap<string, short>().ConvertUsing(AutoMapperTypeConverters.ConvertToInt16);
            CreateMap<string, int>().ConvertUsing(AutoMapperTypeConverters.ConvertToInt32);
            CreateMap<string, int?>().ConvertUsing(AutoMapperTypeConverters.ConvertToNullableInt32);
            CreateMap<DateTime, string>().ConvertUsing(AutoMapperTypeConverters.ConvertDateTimeToString);
            CreateMap<string, DateTime>().ConvertUsing(AutoMapperTypeConverters.ConvertToDateTime);
            CreateMap<string, DateTime?>().ConvertUsing(AutoMapperTypeConverters.ConvertToNullableDateTime);

            CreateMaps();
        }

        protected abstract void CreateMaps();
    }
}