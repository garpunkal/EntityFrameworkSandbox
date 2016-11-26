using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using garpunkal.EntityFrameworkSandbox.Business.Interfaces;
using garpunkal.EntityFrameworkSandbox.Data;
using garpunkal.EntityFrameworkSandbox.Data.Entities;

namespace garpunkal.EntityFrameworkSandbox.Business
{
    public class DeveloperService : IDeveloperService
    {
        private readonly EntityFrameworkSandboxDbContext _dbContext;

        public DeveloperService(EntityFrameworkSandboxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Developer> GetAll()
        {
            return _dbContext.Developers.Where(x => !x.IsDeleted).AsEnumerable();
        }
    }
}
