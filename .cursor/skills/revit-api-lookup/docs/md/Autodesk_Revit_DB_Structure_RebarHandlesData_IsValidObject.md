---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarHandlesData.IsValidObject
source: html/418b8cd1-96ea-5ac9-f03b-5ae5ab43385c.htm
---
# Autodesk.Revit.DB.Structure.RebarHandlesData.IsValidObject Property

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

