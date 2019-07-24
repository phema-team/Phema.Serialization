using Microsoft.Extensions.Options;

namespace Phema.Serialization.Internal
{
	internal sealed class JsonSerializer : ISerializer
	{
		private readonly JsonSerializerOptions options;

		public JsonSerializer(IOptions<JsonSerializerOptions> options)
		{
			this.options = options.Value;
		}

		public TValue Deserialize<TValue>(byte[] data)
		{
			return System.Text.Json.JsonSerializer.Deserialize<TValue>(data);
		}

		public byte[] Serialize<TValue>(TValue value)
		{
			return options.Encoding.GetBytes(System.Text.Json.JsonSerializer.Serialize(value));
		}
	}
}