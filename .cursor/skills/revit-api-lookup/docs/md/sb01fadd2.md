---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.FirstElementId
zh: 筛选、过滤
source: html/b1b42ac5-e816-983a-f44d-5cf441ca1ad9.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.FirstElementId Method

**中文**: 筛选、过滤

Returns the id of the first element to pass the filter(s).

## Syntax (C#)
```csharp
public ElementId FirstElementId()
```

## Returns
The first element id.

## Remarks
This will reset the collector to the beginning and find the first element that passes the applied filter(s).
 If you have an active iterator to this same collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The collector does not have a filter applied. Extraction or iteration of elements is not permitted without a filter.

