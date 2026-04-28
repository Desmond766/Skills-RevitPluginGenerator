---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.WaterLoopData.IsValidObject
source: html/11a7a9d6-377e-db3b-11be-27746dd3d5c9.htm
---
# Autodesk.Revit.DB.Mechanical.WaterLoopData.IsValidObject Property

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

