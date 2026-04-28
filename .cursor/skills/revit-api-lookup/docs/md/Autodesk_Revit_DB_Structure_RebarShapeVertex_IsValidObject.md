---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeVertex.IsValidObject
source: html/beb5d1c9-c52d-3be9-189a-7557551f0424.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeVertex.IsValidObject Property

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

