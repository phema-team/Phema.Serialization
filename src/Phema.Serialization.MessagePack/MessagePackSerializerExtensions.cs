using System;
using Microsoft.Extensions.DependencyInjection;

namespace Phema.Serialization
{
	public static class MessagePackSerializerExtensions
	{
		public static IServiceCollection AddMessagePackSerializer(this IServiceCollection services, Action<MessagePackSerializerOptions> options = null)
		{
			options = options ?? (o => {});
			
			return services.AddSerializer<MessagePackSerializer>()
				.Configure(options);
		}
	}
}