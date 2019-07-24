using System;
using Microsoft.Extensions.DependencyInjection;
using Phema.Serialization.Internal;

namespace Phema.Serialization
{
	public static class JsonSerializerExtensions
	{
		public static IServiceCollection AddJsonSerializer(
			this IServiceCollection services,
			Action<JsonSerializerOptions> options = null)
		{
			options ??= o => { };

			return services.AddSerializer<JsonSerializer>()
				.Configure(options);
		}
	}
}