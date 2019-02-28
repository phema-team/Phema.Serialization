using System;
using Microsoft.Extensions.DependencyInjection;

namespace Phema.Serialization
{
	public static class MessagePackSerializerExtensions
	{
		public static IServiceCollection AddPhemaMessagePackSerializer(this IServiceCollection services, Action<MessagePackSerializerOptions> options = null)
		{
			options = options ?? (o => {});
			
			return services.AddPhemaSerializer<MessagePackSerializer>()
				.Configure(options);
		}
	}
}