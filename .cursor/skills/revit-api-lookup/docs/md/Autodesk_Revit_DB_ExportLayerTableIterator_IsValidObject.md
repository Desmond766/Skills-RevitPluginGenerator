---
kind: property
id: P:Autodesk.Revit.DB.ExportLayerTableIterator.IsValidObject
source: html/d69862b9-16f3-b742-306d-64328e6b449e.htm
---
# Autodesk.Revit.DB.ExportLayerTableIterator.IsValidObject Property

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

