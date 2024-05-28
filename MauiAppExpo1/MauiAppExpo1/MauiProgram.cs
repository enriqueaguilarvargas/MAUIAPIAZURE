using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Hosting;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;

namespace MauiAppExpo1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiMaps()  // Añadir esta línea para usar mapas
                .UseMauiCommunityToolkit() // Inicializar el Community Toolkit
                .UseMauiCommunityToolkitCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}