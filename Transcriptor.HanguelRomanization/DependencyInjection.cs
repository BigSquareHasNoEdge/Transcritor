using Microsoft.Extensions.DependencyInjection;
using Transcriptor.HanguelRomanization.Types;

namespace Transcriptor.HanguelRomanization;

public static class DependencyInjection
{
    public static IServiceCollection AddHangeulRomanizator(this IServiceCollection services)
        => services.AddScoped<ITranscriptor, HangeulRomanizator>();
}
