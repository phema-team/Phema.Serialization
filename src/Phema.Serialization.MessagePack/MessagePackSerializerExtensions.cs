using System;
using MessagePack.Resolvers;
using Microsoft.Extensions.DependencyInjection;

namespace Phema.Serialization
{
	public static class MessagePackSerializerExtensions
	{
		public static IServiceCollection AddMessagePackSerializer(
			this IServiceCollection services,
			Func<MessagePack.MessagePackSerializerOptions, MessagePack.MessagePackSerializerOptions> options = null)
		{
			var withContractlessResolver = MessagePack.MessagePackSerializerOptions.Default
				.WithResolver(ContractlessStandardResolver.Instance);
			
			var serializerOptions = options is null
				? withContractlessResolver
				: options(withContractlessResolver);

			return services.AddSerializer<MessagePackSerializer>()
				.Configure<MessagePackSerializerOptions>(
					o => o.SerializerOptions = serializerOptions);
		}
	}
}