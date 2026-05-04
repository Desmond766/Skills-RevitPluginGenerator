---
kind: property
id: P:Autodesk.Revit.DB.ExportPatternTableIterator.IsValidObject
source: html/c9ee4d62-b88b-b263-b396-0c32f7de9019.htm
---
# Autodesk.Revit.DB.ExportPatternTableIterator.IsValidObject Property

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

