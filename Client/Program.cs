using LargeFileUpload.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace LargeFileUpload.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            var handler = new HttpClientHandler
            {
                // This isn't supported in Blazor. But it appears it is doing it automatically.
                //AutomaticDecompression = System.Net.DecompressionMethods.All,

                // MaxRequestContentBufferSize = 75 * 1000,
            };

            var http = new HttpClient(handler)
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
                Timeout = Timeout.InfiniteTimeSpan,
            };

            builder.Services.AddScoped(sp => http);

            await builder.Build().RunAsync();
        }
    }
}