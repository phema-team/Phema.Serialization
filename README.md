# Phema.Serialization
C# Json, xml and messagepack DI services

```csharp
// JSON
services.AddPhemaJsonSerializer();

// MPCK
services.AddPhemaMessagePackSerializer();

// XML
services.AddPhemaXmlSerializer();

// Resolve
var serializer = provider.GetRequiredService<ISerializer>();

// Serialize
var serialized = serializer.Serialize(model);

// Deserialize
var deserialized = serializer.Deserialize<Model>(serialized);
```
