using System;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Meta;

namespace Phema.Serialization
{
	public static class ProtobufSerializerExtensions
	{
		public static IServiceCollection AddProtobufSerializer(
			this IServiceCollection services,
			Action<RuntimeTypeModel> options = null)
		{
			options?.Invoke(RuntimeTypeModel.Default);

			return services.AddSerializer<ProtobufSerializer>();
		}
	}
}