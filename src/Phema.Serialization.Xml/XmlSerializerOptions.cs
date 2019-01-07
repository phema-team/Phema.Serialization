using System.Text;
using YAXLib;

namespace Phema.Serialization
{
	public class XmlSerializerOptions
	{
		public XmlSerializerOptions()
		{
			Encoding = Encoding.UTF8;
			ExceptionHandlingPolicies = YAXExceptionHandlingPolicies.ThrowWarningsAndErrors;
			ExceptionTypes = YAXExceptionTypes.Error;
			SerializationOptions = YAXSerializationOptions.SerializeNullObjects;
		}

		public Encoding Encoding { get; set; }
		public YAXExceptionHandlingPolicies ExceptionHandlingPolicies { get; set; }
		public YAXExceptionTypes ExceptionTypes { get; set; }
		public YAXSerializationOptions SerializationOptions { get; set; }
	}
}