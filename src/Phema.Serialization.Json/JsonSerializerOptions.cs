using System.Text;

namespace Phema.Serialization
{
	public sealed class JsonSerializerOptions
	{
		public JsonSerializerOptions()
		{
			Encoding = Encoding.UTF8;
		}
		
		public Encoding Encoding { get; set; }
	}
}