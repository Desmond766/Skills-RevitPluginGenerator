---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.WhereElementIsCurveDriven
zh: 筛选、过滤
source: html/3f3269fc-367c-1fec-9ddb-d0b54ecc4f0e.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.WhereElementIsCurveDriven Method

**中文**: 筛选、过滤

Applies an ElementIsCurveDrivenFilter to the collector.

## Syntax (C#)
```csharp
public FilteredElementCollector WhereElementIsCurveDriven()
```

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
Only elements that are curve driven will pass the collector.
 If you have an active iterator to this collector it will be stopped by this call.

