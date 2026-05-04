---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.Excluding(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 筛选、过滤
source: html/80e23fdc-c005-163b-5643-38d84411a73d.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.Excluding Method

**中文**: 筛选、过滤

Applies an ExclusionFilter to the collector.

## Syntax (C#)
```csharp
public FilteredElementCollector Excluding(
	ICollection<ElementId> idsToExclude
)
```

## Parameters
- **idsToExclude** (`System.Collections.Generic.ICollection < ElementId >`) - The ids to exclude from the results.

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
Elements passed to this filter will be automatically excluded from the results.
 If you have an active iterator to this collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input collection of ids was empty, or its contents were not valid for iteration.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

