namespace Phema.Serialization
{
	public class MessagePackSerializerOptions
	{
		public MessagePackSerializerOptions()
		{
			SerializerOptions = MessagePack.MessagePackSerializerOptions.Default;
		}

		public MessagePack.MessagePackSerializerOptions SerializerOptions { get; set; }
	}
}