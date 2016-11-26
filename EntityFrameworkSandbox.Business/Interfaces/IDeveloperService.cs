using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using garpunkal.EntityFrameworkSandbox.Data.Entities;

namespace garpunkal.EntityFrameworkSandbox.Business.Interfaces
{
    public interface IDeveloperService
    {
        IEnumerable<Developer> GetAll();
    }
}
