---
kind: property
id: P:Autodesk.Revit.DB.ExportFontTable.IsValidObject
source: html/e8a68a46-a01e-fbfd-27eb-4a322e6c67d6.htm
---
# Autodesk.Revit.DB.ExportFontTable.IsValidObject Property

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

