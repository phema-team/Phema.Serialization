using MessagePack.Resolvers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Phema.Serialization.MessagePack.Tests
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
				.AddMessagePackSerializer()
				.BuildServiceProvider();

			var options = provider.GetService<IOptions<MessagePackSerializerOptions>>();

			Assert.NotNull(options);
			Assert.NotNull(options.Value);

			Assert.Equal(
				global::MessagePack.MessagePackSerializerOptions
					.Default
					.WithResolver(ContractlessStandardResolver.Instance)
					.Resolver,
				options.Value.SerializerOptions.Resolver);

			Assert.Equal(
				global::MessagePack.MessagePackSerializerOptions
					.Default
					.WithResolver(ContractlessStandardResolver.Instance)
					.UseLZ4Compression,
				options.Value.SerializerOptions.UseLZ4Compression);
		}

		[Fact]
		public void ConfiguresOptions()
		{
			var resolver = new DynamicContractlessObjectResolverAllowPrivate();

			var provider = services
				.AddMessagePackSerializer(o => o.WithResolver(resolver))
				.BuildServiceProvider();

			var options = provider.GetService<IOptions<MessagePackSerializerOptions>>();

			Assert.Equal(resolver, options.Value.SerializerOptions.Resolver);
		}
	}
}