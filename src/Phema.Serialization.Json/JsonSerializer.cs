using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Phema.Serialization
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
			var message = options.Encoding.GetString(data);
			
			return JsonConvert.DeserializeObject<TValue>(message, options.SerializerSettings);
		}

		public byte[] Serialize<TValue>(TValue value)
		{
			var message = JsonConvert.SerializeObject(value, options.SerializerSettings);

			return options.Encoding.GetBytes(message);
		}
	}
}