# Phema.Serialization
C# Json and messagepack DI services

```csharp
// JSON
services.AddJsonSerializer();

// MPCK
services.AddMessagePackSerializer();

// XML
services.AddXmlSerializer();

// Resolve
var serializer = provider.GetRequiredService<ISerializer>();

// Serialize
var serialized = serializer.Serialize(model);

// Deserialize
var deserialized = serializer.Deserialize<Model>(serialized);
```
