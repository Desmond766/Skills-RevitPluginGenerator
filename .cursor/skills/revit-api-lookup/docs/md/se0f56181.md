---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarConstraint.IsValidObject
source: html/a575e7e8-f425-1295-ec8b-5d8a8b66c56d.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.IsValidObject Property

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

