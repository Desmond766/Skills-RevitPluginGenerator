---
kind: property
id: P:Autodesk.Revit.DB.PointClouds.PointIterator.IsValidObject
source: html/dd802021-c167-2c0c-264e-0f2b9e74467d.htm
---
# Autodesk.Revit.DB.PointClouds.PointIterator.IsValidObject Property

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

