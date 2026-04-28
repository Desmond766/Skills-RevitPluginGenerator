---
kind: property
id: P:Autodesk.Revit.DB.ExportLinetypeTable.IsValidObject
source: html/48b9c4fa-fb58-de0a-3394-fe4605e24d6a.htm
---
# Autodesk.Revit.DB.ExportLinetypeTable.IsValidObject Property

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

