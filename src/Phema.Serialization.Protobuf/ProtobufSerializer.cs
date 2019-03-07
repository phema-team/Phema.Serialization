using System.IO;

using Microsoft.Extensions.Options;

using ProtoBuf;

namespace Phema.Serialization
{
	public class ProtobufSerializer : ISerializer
	{
		public TValue Deserialize<TValue>(byte[] data)
		{
			using (var stream = new MemoryStream(data))
			{
				return Serializer.Deserialize<TValue>(stream);
			}
		}

		public byte[] Serialize<TValue>(TValue value)
		{
			using (var stream = new MemoryStream())
			{
				Serializer.Serialize(stream, value);
				
				return stream.ToArray();
			}
		}
	}
}