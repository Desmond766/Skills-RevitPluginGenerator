---
kind: property
id: P:Autodesk.Revit.DB.SpatialElementBoundarySubface.IsValidObject
source: html/79e88553-e0a3-a2f7-4c6f-958e31313d1c.htm
---
# Autodesk.Revit.DB.SpatialElementBoundarySubface.IsValidObject Property

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

