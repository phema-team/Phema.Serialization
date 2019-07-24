using System;
using MessagePack;
using Microsoft.Extensions.Options;

namespace Phema.Serialization
{
	public class MessagePackSerializer : ISerializer
	{
		private readonly MessagePackSerializerOptions options;

		public MessagePackSerializer(IOptions<MessagePackSerializerOptions> options)
		{
			this.options = options.Value;
		}
		
		public TValue Deserialize<TValue>(byte[] data)
		{
			return MessagePack.MessagePackSerializer.Deserialize<TValue>(data.AsMemory(), options.SerializerOptions);
		}

		public byte[] Serialize<TValue>(TValue value)
		{
			return MessagePack.MessagePackSerializer.Serialize(value, options.SerializerOptions);
		}
	}
}