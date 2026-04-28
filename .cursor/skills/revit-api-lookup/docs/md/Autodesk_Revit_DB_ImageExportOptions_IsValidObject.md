---
kind: property
id: P:Autodesk.Revit.DB.ImageExportOptions.IsValidObject
source: html/795ceab7-beda-8a76-58d5-d1f1fbf3910e.htm
---
# Autodesk.Revit.DB.ImageExportOptions.IsValidObject Property

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

