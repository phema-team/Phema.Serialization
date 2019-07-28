# Phema.Serialization

[![Build Status](https://cloud.drone.io/api/badges/phema-team/Phema.Serialization/status.svg)](https://cloud.drone.io/phema-team/Phema.Serialization)

C# Json, xml, protobuf and messagepack wrappers for `Microsoft.Extensions.DependencyInjection`

## Packages

- [![Nuget](https://img.shields.io/nuget/v/Phema.Serialization.svg)](https://www.nuget.org/packages/Phema.Serialization) `Phema.Serialization`
- [![Nuget](https://img.shields.io/nuget/v/Phema.Serialization.Json.svg)](https://www.nuget.org/packages/Phema.Serialization.Json) `Phema.Serialization.Json` - require netcoreapp3.0
- [![Nuget](https://img.shields.io/nuget/v/Phema.Serialization.MessagePack.svg)](https://www.nuget.org/packages/Phema.Serialization.MessagePack) `Phema.Serialization.MessagePack`
- [![Nuget](https://img.shields.io/nuget/v/Phema.Serialization.NewtonsoftJson.svg)](https://www.nuget.org/packages/Phema.Serialization.NewtonsoftJson) `Phema.Serialization.NewtonsoftJson`
- [![Nuget](https://img.shields.io/nuget/v/Phema.Serialization.Protobuf.svg)](https://www.nuget.org/packages/Phema.Serialization.Protobuf) `Phema.Serialization.Protobuf`
- [![Nuget](https://img.shields.io/nuget/v/Phema.Serialization.Xml.svg)](https://www.nuget.org/packages/Phema.Serialization.Xml) `Phema.Serialization.Xml`

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
