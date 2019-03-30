using Microsoft.Extensions.DependencyInjection;

namespace Phema.Serialization
{
	public static class SerializerExtensions
	{
		public static IServiceCollection AddSerializer<TSerializer>(this IServiceCollection services)
			where TSerializer : class, ISerializer
		{
			return services.AddSingleton<ISerializer, TSerializer>();
		}
	}
}