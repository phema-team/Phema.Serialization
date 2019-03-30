using Microsoft.Extensions.DependencyInjection;
using Phema.Serialization.Internal;

namespace Phema.Serialization
{
	public static class JsonSerializerExtensions
	{
		public static IServiceCollection AddJsonSerializer(this IServiceCollection services)
		{
			return services.AddSerializer<JsonSerializer>();
		}
	}
}