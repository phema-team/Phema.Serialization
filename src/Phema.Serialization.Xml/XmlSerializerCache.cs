using System;
using System.Collections.Generic;
using YAXLib;

namespace Phema.Serialization
{
	internal static class XmlSerializerCache
	{
		private static readonly IDictionary<Type, YAXSerializer> Cache;

		public static YAXSerializer GetOrCreate<TValue>(XmlSerializerOptions options)
		{
			var type = typeof(TValue);
			
			if (!Cache.TryGetValue(type, out var serializer))
			{
				Cache.Add(type, serializer = new YAXSerializer(
					type,
					options.ExceptionHandlingPolicies,
					options.ExceptionTypes,
					options.SerializationOptions));
			}

			return serializer;
		}
		
		static XmlSerializerCache()
		{
			Cache = new Dictionary<Type, YAXSerializer>();
		}
	}
}