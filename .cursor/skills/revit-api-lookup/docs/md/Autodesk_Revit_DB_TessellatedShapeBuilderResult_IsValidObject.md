---
kind: property
id: P:Autodesk.Revit.DB.TessellatedShapeBuilderResult.IsValidObject
source: html/8b8076fd-3775-a91b-40f2-fb7145028d66.htm
---
# Autodesk.Revit.DB.TessellatedShapeBuilderResult.IsValidObject Property

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

