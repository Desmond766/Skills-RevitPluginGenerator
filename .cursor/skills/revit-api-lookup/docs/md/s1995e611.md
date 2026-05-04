---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.WherePasses(Autodesk.Revit.DB.ElementFilter)
zh: 筛选、过滤
source: html/42d4eef3-55a1-2739-0ef8-6bc1d9fc2755.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.WherePasses Method

**中文**: 筛选、过滤

Applies an element filter to the collector.

## Syntax (C#)
```csharp
public FilteredElementCollector WherePasses(
	ElementFilter filter
)
```

## Parameters
- **filter** (`Autodesk.Revit.DB.ElementFilter`) - The element filter.

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
The filter will be added as an additional condition that all filtered elements must pass.
 If you have an active iterator to this collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

