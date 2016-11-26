using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using garpunkal.EntityFrameworkSandbox.Data.Entities;
using garpunkal.EntityFrameworkSandbox.Web.Models;

namespace garpunkal.EntityFrameworkSandbox.Web.AutoMapper
{
    public class DeveloperProfile : BaseProfile
    {
        public DeveloperProfile() : base("DeveloperProfile") { }

        protected override void CreateMaps()
        {
            CreateMap<Developer, DeveloperViewModel>();

            CreateMap<DeveloperViewModel, Developer>()
                .ForMember(d => d.IsDeleted, o => o.Ignore())
                .ForMember(d => d.UpdatedDateTime, o => o.Ignore())
                .ForMember(d => d.CreatedDateTime, o => o.Ignore())
                .ForMember(d => d.RowVersion, o => o.Ignore());
        }
    }
}