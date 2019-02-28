using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;
using YAXLib;

namespace Phema.Serialization.Xml.Tests
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
				.AddPhemaXmlSerializer()
				.BuildServiceProvider();

			var options = provider.GetService<IOptions<XmlSerializerOptions>>();
			
			Assert.NotNull(options);
			Assert.NotNull(options.Value);
			Assert.Equal(Encoding.UTF8, options.Value.Encoding);
			Assert.Equal(YAXExceptionTypes.Error, options.Value.ExceptionTypes);
			Assert.Equal(YAXSerializationOptions.SerializeNullObjects, options.Value.SerializationOptions);
			Assert.Equal(YAXExceptionHandlingPolicies.ThrowWarningsAndErrors, options.Value.ExceptionHandlingPolicies);
		}
		
		[Fact]
		public void ConfiguresOptions()
		{
			var provider = services
				.AddPhemaXmlSerializer(o =>
				{
					o.Encoding = Encoding.ASCII;
					o.ExceptionTypes = YAXExceptionTypes.Ignore;
					o.SerializationOptions = YAXSerializationOptions.SuppressMetadataAttributes;
					o.ExceptionHandlingPolicies = YAXExceptionHandlingPolicies.DoNotThrow;
				})
				.BuildServiceProvider();

			var options = provider.GetService<IOptions<XmlSerializerOptions>>();

			Assert.Equal(Encoding.ASCII, options.Value.Encoding);
			Assert.Equal(YAXExceptionTypes.Ignore, options.Value.ExceptionTypes);
			Assert.Equal(YAXSerializationOptions.SuppressMetadataAttributes, options.Value.SerializationOptions);
			Assert.Equal(YAXExceptionHandlingPolicies.DoNotThrow, options.Value.ExceptionHandlingPolicies);
		}
	}
}