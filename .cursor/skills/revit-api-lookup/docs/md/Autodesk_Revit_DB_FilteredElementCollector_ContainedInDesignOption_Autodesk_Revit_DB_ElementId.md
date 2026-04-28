---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.ContainedInDesignOption(Autodesk.Revit.DB.ElementId)
zh: 筛选、过滤
source: html/92a2be0f-f632-2337-5bdd-ae3e832f3c33.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.ContainedInDesignOption Method

**中文**: 筛选、过滤

Applies an ElementDesignOptionFilter to the collector.

## Syntax (C#)
```csharp
public FilteredElementCollector ContainedInDesignOption(
	ElementId designOptionId
)
```

## Parameters
- **designOptionId** (`Autodesk.Revit.DB.ElementId`) - The design option id.

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
Only elements that are contained by this particular design option will pass the collector.
 If you have an active iterator to this collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

