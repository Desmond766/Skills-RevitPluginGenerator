---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.WhereElementIsNotElementType
zh: 筛选、过滤
source: html/061cbbb9-26f1-a8f8-a4b2-3d7ff0105199.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.WhereElementIsNotElementType Method

**中文**: 筛选、过滤

Applies an inverted ElementIsElementTypeFilter to the collector.

## Syntax (C#)
```csharp
public FilteredElementCollector WhereElementIsNotElementType()
```

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
Only elements that are not element types will pass the collector.
 If you have an active iterator to this collector it will be stopped by this call.

