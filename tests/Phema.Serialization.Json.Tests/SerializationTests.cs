using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Phema.Serialization.Json.Tests
{
	public class SerializationTests
	{
		private class Person
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}

		[Fact]
		public void Serialization()
		{
			var provider = new ServiceCollection()
				.AddJsonSerializer()
				.BuildServiceProvider();

			var options = provider.GetRequiredService<IOptions<JsonSerializerOptions>>().Value;
			var serializer = provider.GetRequiredService<ISerializer>();

			var person = new Person
			{
				Name = "Sarah", Age = 12
			};

			var data = serializer.Serialize(person);

			var message = options.Encoding.GetString(data);

			var json = JObject.Parse(message);

			Assert.Equal(2, json.Count);

			Assert.Collection<JToken>(json,
				name =>
				{
					Assert.Equal("Name", name.Path);
					Assert.Equal("Sarah", name.ToObject<string>());
				},
				age =>
				{
					Assert.Equal("Age", age.Path);
					Assert.Equal(12, age.ToObject<int>());
				});
		}

		[Fact]
		public void Deserialization()
		{
			var provider = new ServiceCollection()
				.AddJsonSerializer()
				.BuildServiceProvider();

			var options = provider.GetRequiredService<IOptions<JsonSerializerOptions>>().Value;
			var serializer = provider.GetRequiredService<ISerializer>();

			var data = @"{""Name"": ""Sarah"", ""Age"": 12}";

			var message = options.Encoding.GetBytes(data);

			var person = serializer.Deserialize<Person>(message);

			Assert.Equal("Sarah", person.Name);
			Assert.Equal(12, person.Age);
		}
	}
}