using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace Phema.Serialization.Tests
{
	public class StabSerializer : ISerializer
	{
		public TValue Deserialize<TValue>(byte[] data)
		{
			throw new System.NotImplementedException();
		}

		public byte[] Serialize<TValue>(TValue value)
		{
			throw new System.NotImplementedException();
		}
	}

	public class ServiceCollectionTests
	{
		private readonly IServiceCollection services;

		public ServiceCollectionTests()
		{
			services = new ServiceCollection()
				.AddSerializer<StabSerializer>();
		}

		[Fact]
		public void AddsSerializerToCollection()
		{
			Assert.Single(services);
		}

		[Fact]
		public void SingletonSerializer()
		{
			var service = Assert.Single(services);

			Assert.Equal(ServiceLifetime.Singleton, service.Lifetime);
		}

		[Fact]
		public void AsISerializerSerializer()
		{
			var service = Assert.Single(services);

			Assert.Equal(typeof(ISerializer), service.ServiceType);
		}

		[Fact]
		public void ImplementationSerializer()
		{
			var service = Assert.Single(services);

			Assert.Equal(typeof(StabSerializer), service.ImplementationType);
		}
	}
}