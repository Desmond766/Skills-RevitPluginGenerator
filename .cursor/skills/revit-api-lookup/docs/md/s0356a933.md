---
kind: property
id: P:Autodesk.Revit.DB.ViewCropRegionShapeManager.IsValidObject
source: html/ff38ac8e-6b3b-f9a4-6a26-2669eb661361.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.IsValidObject Property

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

