using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceTemplate.Data.Abstractions;
using ServiceTemplate.Data.Entities;

namespace ServiceTemplate.Data.Repositories
{
    public class TestRepository : ITestRepository
    {
        private IDbContextFactory<Context> _factory { get; set; }

        public TestRepository(IDbContextFactory<Context> factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<TestEntity>> GetAll()
        {
            using var context = _factory.CreateDbContext();
            var entities = await context.TestEntities.ToListAsync();
            return entities;
        }
    }
}
