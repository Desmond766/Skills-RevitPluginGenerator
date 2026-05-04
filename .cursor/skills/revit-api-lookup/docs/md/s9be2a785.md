---
kind: property
id: P:Autodesk.Revit.DB.WorksharingUtils.IsValidObject
source: html/6f86ac74-bb9d-56b0-eb5c-fbaeb169ef3e.htm
---
# Autodesk.Revit.DB.WorksharingUtils.IsValidObject Property

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

