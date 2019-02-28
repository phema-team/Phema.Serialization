using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Phema.Serialization.Xml.Tests
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
				.AddPhemaXmlSerializer()
				.BuildServiceProvider();

			var options = provider.GetRequiredService<IOptions<XmlSerializerOptions>>().Value;
			var serializer = provider.GetRequiredService<ISerializer>();

			var person = new Person
			{
				Name = "Sarah", Age = 12
			};

			var data = serializer.Serialize(person);

			var message = options.Encoding.GetString(data);

			var xml = new XDocument(
				new XElement("Person", 
					new XElement("Name", "Sarah"),
					new XElement("Age", "12")))
				.ToString();
			
			Assert.Equal(xml, message);
		}
		
		[Fact]
		public void Deserialization()
		{
			var provider = new ServiceCollection()
				.AddPhemaXmlSerializer()
				.BuildServiceProvider();

			var options = provider.GetRequiredService<IOptions<XmlSerializerOptions>>().Value;
			var serializer = provider.GetRequiredService<ISerializer>();

			var data = new XDocument(
				new XElement("Person", 
					new XElement("Name", "Sarah"),
					new XElement("Age", "12")))
				.ToString();

			var message = options.Encoding.GetBytes(data);
			
			var person = serializer.Deserialize<Person>(message);

			Assert.Equal("Sarah", person.Name);
			Assert.Equal(12, person.Age);
		}
	}
}