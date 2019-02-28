using System;
using Microsoft.Extensions.DependencyInjection;

namespace Phema.Serialization
{
	public static class XmlSerializerExtensions
	{
		public static IServiceCollection AddPhemaXmlSerializer(this IServiceCollection services, Action<XmlSerializerOptions> options = null)
		{
			options = options ?? (o => {});
			
			return services.AddPhemaSerializer<XmlSerializer>()
				.Configure(options);
		}
	}
}