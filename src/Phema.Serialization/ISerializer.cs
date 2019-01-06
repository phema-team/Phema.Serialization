namespace Phema.Serialization
{
	public interface ISerializer
	{
		TValue Deserialize<TValue>(byte[] data);
		byte[] Serialize<TValue>(TValue value);
	}
}