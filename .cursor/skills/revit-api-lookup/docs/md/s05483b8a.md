---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.WhereElementIsElementType
zh: 筛选、过滤
source: html/77793daa-5a26-b4d6-9019-4d998a55099e.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.WhereElementIsElementType Method

**中文**: 筛选、过滤

Applies an ElementIsElementTypeFilter to the collector.

## Syntax (C#)
```csharp
public FilteredElementCollector WhereElementIsElementType()
```

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
Only elements that are ElementTypes will pass the collector.
 If you have an active iterator to this collector it will be stopped by this call.

