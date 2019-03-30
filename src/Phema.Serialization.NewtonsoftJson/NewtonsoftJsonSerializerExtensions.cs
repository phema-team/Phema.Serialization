using System;
using Microsoft.Extensions.DependencyInjection;
using Phema.Serialization.Internal;

namespace Phema.Serialization
{
	public static class NewtonsoftJsonSerializerExtensions
	{
		public static IServiceCollection AddNewtonsoftJsonSerializer(this IServiceCollection services,
			Action<NewtonsoftJsonSerializerOptions> options = null)
		{
			return services.AddSerializer<NewtonsoftJsonSerializer>()
				.Configure(options ?? (o => { }));
		}
	}
}