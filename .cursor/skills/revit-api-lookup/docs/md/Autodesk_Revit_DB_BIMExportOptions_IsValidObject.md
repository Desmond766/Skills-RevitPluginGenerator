---
kind: property
id: P:Autodesk.Revit.DB.BIMExportOptions.IsValidObject
source: html/9058bdf4-f93c-7ab2-c8d7-7e513df52e85.htm
---
# Autodesk.Revit.DB.BIMExportOptions.IsValidObject Property

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

