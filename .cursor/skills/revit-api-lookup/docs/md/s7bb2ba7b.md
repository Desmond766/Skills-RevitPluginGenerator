---
kind: property
id: P:Autodesk.Revit.DB.ExportLayerInfo.IsValidObject
source: html/d00d4127-b409-ba78-c78e-b5a272548217.htm
---
# Autodesk.Revit.DB.ExportLayerInfo.IsValidObject Property

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

