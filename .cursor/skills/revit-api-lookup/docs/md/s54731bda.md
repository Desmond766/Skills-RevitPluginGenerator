---
kind: property
id: P:Autodesk.Revit.DB.PointClouds.PointCloudOverrides.IsValidObject
source: html/90257c8c-930e-d0b9-87d6-92fe445e62c3.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudOverrides.IsValidObject Property

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

