using Microsoft.Extensions.Options;

namespace Phema.Serialization
{
	internal class XmlSerializer : ISerializer
	{
		private readonly XmlSerializerOptions options;

		public XmlSerializer(IOptions<XmlSerializerOptions> options)
		{
			this.options = options.Value;
		}
		
		public TValue Deserialize<TValue>(byte[] data)
		{
			var serializer = XmlSerializerCache.GetOrCreate<TValue>(options);

			var message = options.Encoding.GetString(data);

			return (TValue)serializer.Deserialize(message);
		}

		public byte[] Serialize<TValue>(TValue value)
		{
			var serializer = XmlSerializerCache.GetOrCreate<TValue>(options);

			var message = serializer.Serialize(value);

			return options.Encoding.GetBytes(message);
		}
	}
}