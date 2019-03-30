using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Phema.Serialization.Json.Tests
{
	public class SerializationTests
	{
		public class Person
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}

		[Fact]
		public void Serialization()
		{
			var serializer = new ServiceCollection()
				.AddMessagePackSerializer()
				.BuildServiceProvider()
				.GetRequiredService<ISerializer>();

			var person = new Person
			{
				Name = "Sarah", Age = 12
			};

			var data = serializer.Serialize(person);

			var expected = Convert.FromBase64String("gqROYW1lpVNhcmFoo0FnZQw=");
			
			Assert.Equal(expected, data);
		}

		[Fact]
		public void Deserialization()
		{
			var serializer = new ServiceCollection()
				.AddMessagePackSerializer()
				.BuildServiceProvider()
				.GetRequiredService<ISerializer>();

			var data = Convert.FromBase64String("gqROYW1lpVNhcmFoo0FnZQw=");

			var person = serializer.Deserialize<Person>(data);

			Assert.Equal("Sarah", person.Name);
			Assert.Equal(12, person.Age);
		}
	}
}