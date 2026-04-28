---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.WhereElementIsViewIndependent
zh: 筛选、过滤
source: html/38b15459-9ffe-204a-0193-47c3a1b5e6e2.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.WhereElementIsViewIndependent Method

**中文**: 筛选、过滤

Applies an ElementOwnerViewFilter to the collector.

## Syntax (C#)
```csharp
public FilteredElementCollector WhereElementIsViewIndependent()
```

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
Only elements that are view independent will pass the collector.
 If you have an active iterator to this collector it will be stopped by this call.

