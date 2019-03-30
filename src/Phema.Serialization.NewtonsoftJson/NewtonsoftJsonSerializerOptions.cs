using System.Text;
using Newtonsoft.Json;

namespace Phema.Serialization
{
	public class NewtonsoftJsonSerializerOptions
	{
		public NewtonsoftJsonSerializerOptions()
		{
			Encoding = Encoding.UTF8;
			SerializerSettings = new JsonSerializerSettings();
		}

		public Encoding Encoding { get; set; }
		public JsonSerializerSettings SerializerSettings { get; set; }
	}
}