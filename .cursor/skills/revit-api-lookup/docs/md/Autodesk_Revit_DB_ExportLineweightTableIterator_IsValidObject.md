---
kind: property
id: P:Autodesk.Revit.DB.ExportLineweightTableIterator.IsValidObject
source: html/83ca0005-4722-2b92-21b6-7be74e1b6d8b.htm
---
# Autodesk.Revit.DB.ExportLineweightTableIterator.IsValidObject Property

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

