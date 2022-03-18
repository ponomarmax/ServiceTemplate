using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Oneview.Inpatient.Logging.ApiDemo;

namespace ServiceTemplate.IntegrationTests
{
    public class SUTFactory : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return Program.CreateHostBuilder(null)
                .ConfigureAppConfiguration(
                    x => x.AddJsonFile("appsettings.tests.json", optional: false)
                );
        }
    }
}
