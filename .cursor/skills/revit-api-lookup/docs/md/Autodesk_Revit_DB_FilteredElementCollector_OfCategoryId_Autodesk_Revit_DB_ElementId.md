---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.OfCategoryId(Autodesk.Revit.DB.ElementId)
zh: 筛选、过滤
source: html/63304108-73f8-844e-82fc-5b8fad9839b0.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.OfCategoryId Method

**中文**: 筛选、过滤

Applies an ElementCategoryFilter to the collector.

## Syntax (C#)
```csharp
public FilteredElementCollector OfCategoryId(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category id.

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
Only elements of this category id will pass the collector.
 If you have an active iterator to this collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

