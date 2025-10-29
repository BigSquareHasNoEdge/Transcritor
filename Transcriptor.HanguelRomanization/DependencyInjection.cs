using Microsoft.Extensions.DependencyInjection;

namespace Transcriptor.HanguelRomanization;
public static class DependencyInjection
{
    public static IServiceCollection AddHangeulRomanizator(this IServiceCollection services)
        => services.AddScoped<ITranscriptor, HanguelRomanizator>();
}
