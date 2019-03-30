namespace Phema.Serialization.Internal
{
	internal sealed class JsonSerializer : ISerializer
	{
		public TValue Deserialize<TValue>(byte[] data)
		{
			throw new System.NotImplementedException("Not implemented yet =( Use Phema.Serialization.NewtonsoftJson package");
		}

		public byte[] Serialize<TValue>(TValue value)
		{
			throw new System.NotImplementedException("Not implemented yet =( Use Phema.Serialization.NewtonsoftJson package");
		}
	}
}