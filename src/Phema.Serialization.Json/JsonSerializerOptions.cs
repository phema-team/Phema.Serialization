using System.Text;
using Newtonsoft.Json;

namespace Phema.Serialization
{
	public class JsonSerializerOptions
	{
		public JsonSerializerOptions()
		{
			Encoding = Encoding.UTF8;
			SerializerSettings = new JsonSerializerSettings();
		}

		public Encoding Encoding { get; set; }
		public JsonSerializerSettings SerializerSettings { get; set; }
	}
}