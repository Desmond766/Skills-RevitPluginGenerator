---
kind: property
id: P:Autodesk.Revit.DB.FamilySizeTableErrorInfo.IsValidObject
source: html/1b268ee5-d666-03fd-e41c-f92f487fe45e.htm
---
# Autodesk.Revit.DB.FamilySizeTableErrorInfo.IsValidObject Property

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

