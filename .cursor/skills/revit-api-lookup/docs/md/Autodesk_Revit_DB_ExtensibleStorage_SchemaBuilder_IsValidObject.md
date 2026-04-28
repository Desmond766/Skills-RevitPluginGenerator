---
kind: property
id: P:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.IsValidObject
source: html/eb116832-fc35-09d3-b76f-8276e8038154.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.IsValidObject Property

Specifies whether the .NET object represents a valid Revit entity.

## Syntax (C#)
```csharp
public bool IsValidObject { get; }
```

## Returns
True if the API object holds a valid Revit native object, false otherwise.

## Remarks
If the corresponding Revit native object is destroyed, or creation of the corresponding object is undone,
 a managed API object containing it is no longer valid. API methods cannot be called on invalidated wrapper objects.

