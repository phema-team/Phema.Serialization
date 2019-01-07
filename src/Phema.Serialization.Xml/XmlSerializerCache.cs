using System;
using System.Collections.Generic;
using YAXLib;

namespace Phema.Serialization
{
	internal static class XmlSerializerCache
	{
		private static readonly IDictionary<Type, YAXSerializer> cache;

		public static YAXSerializer GetOrCreate<TValue>(XmlSerializerOptions options)
		{
			var type = typeof(TValue);
			
			if (!cache.TryGetValue(type, out var serializer))
			{
				cache.Add(type, serializer = new YAXSerializer(
					type,
					options.ExceptionHandlingPolicies,
					options.ExceptionTypes,
					options.SerializationOptions));
			}

			return serializer;
		}
		
		static XmlSerializerCache()
		{
			cache = new Dictionary<Type, YAXSerializer>();
		}
	}
}