---
kind: property
id: P:Autodesk.Revit.DB.PointClouds.PointCloudColorSettings.IsValidObject
source: html/d9c98911-474d-8ba3-5f57-98338d043a7f.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudColorSettings.IsValidObject Property

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

