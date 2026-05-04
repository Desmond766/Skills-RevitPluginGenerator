---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.IntersectWith(Autodesk.Revit.DB.FilteredElementCollector)
zh: 筛选、过滤
source: html/5b204fc8-7702-cf7e-346a-3a4c1767924b.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.IntersectWith Method

**中文**: 筛选、过滤

Intersects the set of elements passing the filter in this collector
 with the set of elements passing the filter in another collector.

## Syntax (C#)
```csharp
public FilteredElementCollector IntersectWith(
	FilteredElementCollector other
)
```

## Parameters
- **other** (`Autodesk.Revit.DB.FilteredElementCollector`) - The other collector

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
The result will be the same as using a LogicalAndFilter to connect this filter with another.
 If you have an active iterator to this collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The collector does not have a filter applied. Extraction or iteration of elements is not permitted without a filter.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The collector does not have a filter applied. Extraction or iteration of elements is not permitted without a filter.

