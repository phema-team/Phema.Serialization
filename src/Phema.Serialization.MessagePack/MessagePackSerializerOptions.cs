using MessagePack;
using MessagePack.Resolvers;

namespace Phema.Serialization
{
	public class MessagePackSerializerOptions
	{
		public MessagePackSerializerOptions()
		{
			FormatterResolver = ContractlessStandardResolver.Instance;
		}

		public IFormatterResolver FormatterResolver { get; set; }
	}
}