---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeMultiplanarDefinition.IsValidObject
source: html/79eb0f31-fe7c-16c9-0825-79c73c4f9fff.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeMultiplanarDefinition.IsValidObject Property

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

