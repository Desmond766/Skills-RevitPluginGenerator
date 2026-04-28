---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.OwnedByView(Autodesk.Revit.DB.ElementId)
zh: 筛选、过滤
source: html/54f2107a-bd87-41fe-dd00-385253ba5915.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.OwnedByView Method

**中文**: 筛选、过滤

Applies an ElementOwnerViewFilter to the collector.

## Syntax (C#)
```csharp
public FilteredElementCollector OwnedByView(
	ElementId viewId
)
```

## Parameters
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id of the owner view.

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
Only elements that are owned by this particular view will pass the collector.
 If you have an active iterator to this collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

