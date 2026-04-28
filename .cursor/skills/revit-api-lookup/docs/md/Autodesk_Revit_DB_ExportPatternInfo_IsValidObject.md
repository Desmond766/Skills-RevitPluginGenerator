---
kind: property
id: P:Autodesk.Revit.DB.ExportPatternInfo.IsValidObject
source: html/30b15891-9a9c-7fd1-62bc-68fcdabea59d.htm
---
# Autodesk.Revit.DB.ExportPatternInfo.IsValidObject Property

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

