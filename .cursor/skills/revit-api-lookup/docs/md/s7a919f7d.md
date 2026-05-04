---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ConduitSizes.IsValidObject
source: html/a4c1ef25-5d87-55d3-5447-4793f941f30b.htm
---
# Autodesk.Revit.DB.Electrical.ConduitSizes.IsValidObject Property

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

