using System;
using Microsoft.Extensions.DependencyInjection;

namespace Phema.Serialization
{
	public static class JsonSerializerExtensions
	{
		public static IServiceCollection AddJsonSerializer(this IServiceCollection services, Action<JsonSerializerOptions> options = null)
		{
			options = options ?? (o => {});
			
			return services.AddSerializer<JsonSerializer>()
				.Configure(options);
		}
	}
}