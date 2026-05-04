---
kind: property
id: P:Autodesk.Revit.DB.MeshFromGeometryOperationResult.IsValidObject
source: html/fff8becb-ceed-55e1-3977-8ea49762b48b.htm
---
# Autodesk.Revit.DB.MeshFromGeometryOperationResult.IsValidObject Property

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

