using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWebAssemblyIdiomas.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddLocalization();

            var host = builder.Build();
            var js = host.Services.GetRequiredService<IJSRuntime>();
            var cultura = await js.InvokeAsync<string>("cultura.get");

            if (cultura == null)
            {
                var culturaPorDefecto = new CultureInfo("en-US");
                CultureInfo.DefaultThreadCurrentCulture = culturaPorDefecto;
                CultureInfo.DefaultThreadCurrentUICulture = culturaPorDefecto;
            }
            else
            {
                var culturaUsuario = new CultureInfo(cultura);
                CultureInfo.DefaultThreadCurrentCulture = culturaUsuario;
                CultureInfo.DefaultThreadCurrentUICulture = culturaUsuario;
            }

            await builder.Build().RunAsync();
        }
    }
}
