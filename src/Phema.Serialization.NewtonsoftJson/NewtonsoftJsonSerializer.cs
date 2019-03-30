using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Phema.Serialization.Internal
{
	internal sealed class NewtonsoftJsonSerializer : ISerializer
	{
		private readonly NewtonsoftJsonSerializerOptions options;

		public NewtonsoftJsonSerializer(IOptions<NewtonsoftJsonSerializerOptions> options)
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