---
kind: property
id: P:Autodesk.Revit.DB.ExternalGeometryId.IsValidObject
source: html/e46bcbe0-f30b-19ec-158b-3234c53bc84e.htm
---
# Autodesk.Revit.DB.ExternalGeometryId.IsValidObject Property

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

