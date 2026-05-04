---
kind: property
id: P:Autodesk.Revit.DB.SlabShapeVertex.IsValidObject
source: html/3a8217e0-b7b9-07ec-0940-aef6cdec70d3.htm
---
# Autodesk.Revit.DB.SlabShapeVertex.IsValidObject Property

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

