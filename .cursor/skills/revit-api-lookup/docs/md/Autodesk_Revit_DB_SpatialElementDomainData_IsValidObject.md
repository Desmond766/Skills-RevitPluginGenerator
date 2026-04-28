---
kind: property
id: P:Autodesk.Revit.DB.SpatialElementDomainData.IsValidObject
source: html/4365cb63-c7a0-a7d3-67a9-da88648c4104.htm
---
# Autodesk.Revit.DB.SpatialElementDomainData.IsValidObject Property

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

