---
kind: property
id: P:Autodesk.Revit.DB.ExportPatternTable.IsValidObject
source: html/a2511284-d9d9-3b11-db2f-206ca5d83f9b.htm
---
# Autodesk.Revit.DB.ExportPatternTable.IsValidObject Property

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

