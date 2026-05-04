---
kind: type
id: T:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder
source: html/e74f9357-cc3c-558e-73b8-38ce6d247869.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder

This class is used to create Schemas in the Extensible Storage framework.

## Syntax (C#)
```csharp
public class SchemaBuilder : IDisposable
```

## Remarks
Named parameter idiom: Methods that set up the Schema return a reference to the builder so
 you can invoke multiple methods in a chain
 (e.g., builder.setReadAccessLevel(...).setWriteAccessLevel(...)).
 Methods that add fields return a FieldBuilder instead.

