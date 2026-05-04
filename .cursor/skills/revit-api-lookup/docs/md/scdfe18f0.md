---
kind: property
id: P:Autodesk.Revit.DB.ExportLayerTable.IsValidObject
source: html/ba72c072-ccd2-8a1b-43bc-ede619e9a9f2.htm
---
# Autodesk.Revit.DB.ExportLayerTable.IsValidObject Property

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

