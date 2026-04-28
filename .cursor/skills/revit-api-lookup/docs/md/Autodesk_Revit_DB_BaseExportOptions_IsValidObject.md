---
kind: property
id: P:Autodesk.Revit.DB.BaseExportOptions.IsValidObject
source: html/787dd92b-1ea4-be3d-7aab-dc061c5b448e.htm
---
# Autodesk.Revit.DB.BaseExportOptions.IsValidObject Property

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

