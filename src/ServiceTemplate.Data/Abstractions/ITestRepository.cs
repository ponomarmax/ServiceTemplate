using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceTemplate.Data.Entities;

namespace ServiceTemplate.Data.Abstractions
{
    public interface ITestRepository
    {
        Task<IEnumerable<TestEntity>> GetAll();
    }
}
