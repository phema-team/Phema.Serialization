using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using YAXLib;

namespace Phema.Serialization
{
	internal static class XmlSerializerCache
	{
		private static readonly IDictionary<Type, YAXSerializer> map;

		public static YAXSerializer GetOrCreate<TValue>(XmlSerializerOptions options)
		{
			var type = typeof(TValue);
			
			if (!map.TryGetValue(type, out var serializer))
			{
				map.Add(type, serializer = new YAXSerializer(
					type,
					options.ExceptionHandlingPolicies,
					options.ExceptionTypes,
					options.SerializationOptions));
			}

			return serializer;
		}
		
		static XmlSerializerCache()
		{
			map = new Dictionary<Type, YAXSerializer>();
		}
	}
	
	internal class XmlSerializer : ISerializer
	{
		private readonly XmlSerializerOptions options;

		public XmlSerializer(IOptions<XmlSerializerOptions> options)
		{
			this.options = options.Value;
		}
		
		public TValue Deserialize<TValue>(byte[] data)
		{
			var serializer = XmlSerializerCache.GetOrCreate<TValue>(options);

			var message = options.Encoding.GetString(data);

			return (TValue)serializer.Deserialize(message);
		}

		public byte[] Serialize<TValue>(TValue value)
		{
			var serializer = XmlSerializerCache.GetOrCreate<TValue>(options);

			var message = serializer.Serialize(value);

			return options.Encoding.GetBytes(message);
		}
	}
}