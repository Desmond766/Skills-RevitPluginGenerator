---
kind: property
id: P:Autodesk.Revit.DB.FillGrid.IsValidObject
source: html/076c03d2-6659-3f1e-40e8-cc1d4810984b.htm
---
# Autodesk.Revit.DB.FillGrid.IsValidObject Property

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

