# Phema.Serialization

[![Nuget](https://img.shields.io/nuget/v/Phema.Serialization.svg)](https://www.nuget.org/packages/Phema.Serialization)

C# Json, xml, protobuf and messagepack wrappers for `Microsoft.Extensions.DependencyInjection`

## Usage

```csharp

// Json
services.AddJsonSerializer();

// Newtonsoft.Json
services.AddNewtonsoftJsonSerializer();

// MessagePack
services.AddMessagePackSerializer();

// XML
services.AddXmlSerializer();

// Protobuf
services.AddProtobufSerializer();

// Resolve
var serializer = provider.GetRequiredService<ISerializer>();

// Serialize
var serialized = serializer.Serialize(model);

// Deserialize
var deserialized = serializer.Deserialize<Model>(serialized);
```
