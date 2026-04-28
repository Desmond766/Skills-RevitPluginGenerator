---
kind: property
id: P:Autodesk.Revit.DB.FilteredElementCollector.IsValidObject
zh: 筛选、过滤
source: html/259b95d7-5686-d69c-669f-904c3b08d6c8.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.IsValidObject Property

**中文**: 筛选、过滤

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

