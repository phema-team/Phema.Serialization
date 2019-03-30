using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Phema.Serialization.Json.Tests
{
	public class SerializationTests
	{
		[Fact]
		public void Serialization()
		{
			var provider = new ServiceCollection()
				.AddJsonSerializer()
				.BuildServiceProvider();

			var serializer = provider.GetRequiredService<ISerializer>();

			Assert.Throws<NotImplementedException>(() => serializer.Serialize(""));
			Assert.Throws<NotImplementedException>(() => serializer.Deserialize<string>(Array.Empty<byte>()));
		}
	}
}