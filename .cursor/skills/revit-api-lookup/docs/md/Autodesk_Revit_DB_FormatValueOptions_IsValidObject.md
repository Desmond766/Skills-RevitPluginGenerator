---
kind: property
id: P:Autodesk.Revit.DB.FormatValueOptions.IsValidObject
source: html/ab4f7c8d-ddbf-a93d-ae46-aef2459c9e4d.htm
---
# Autodesk.Revit.DB.FormatValueOptions.IsValidObject Property

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

