---
kind: property
id: P:Autodesk.Revit.DB.FolderItemInfo.IsValidObject
source: html/6d47a372-7001-e819-6a25-3bb5d77ee472.htm
---
# Autodesk.Revit.DB.FolderItemInfo.IsValidObject Property

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

