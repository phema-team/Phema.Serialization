using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Xunit;

namespace Phema.Serialization.Json.Tests
{
	public class OptionsTests
	{
		private readonly IServiceCollection services;

		public OptionsTests()
		{
			services = new ServiceCollection();
		}
		
		[Fact]
		public void AddsOptions()
		{
			var provider = services
				.AddJsonSerializer()
				.BuildServiceProvider();

			var options = provider.GetService<IOptions<JsonSerializerOptions>>();
			
			Assert.NotNull(options);
			Assert.NotNull(options.Value);
			Assert.NotNull(options.Value.SerializerSettings);
		}
		
		[Fact]
		public void ConfiguresOptions()
		{
			var settings = new JsonSerializerSettings();
			
			var provider = services
				.AddJsonSerializer(o =>
				{
					o.Encoding = Encoding.ASCII;
					o.SerializerSettings = settings;
				})
				.BuildServiceProvider();

			var options = provider.GetService<IOptions<JsonSerializerOptions>>();

			Assert.Equal(Encoding.ASCII, options.Value.Encoding);
			Assert.Equal(settings, options.Value.SerializerSettings);
		}
	}
}