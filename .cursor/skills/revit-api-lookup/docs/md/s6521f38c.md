---
kind: property
id: P:Autodesk.Revit.DB.WorksetPreview.IsValidObject
source: html/6cab1bbf-1f6a-775b-74aa-2bdaa2bd9b9c.htm
---
# Autodesk.Revit.DB.WorksetPreview.IsValidObject Property

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

