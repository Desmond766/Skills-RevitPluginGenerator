---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.OfClass(System.Type)
zh: 筛选、过滤
source: html/b0a5f22c-6951-c3af-cd29-1f28f574035d.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.OfClass Method

**中文**: 筛选、过滤

Applies an ElementClassFilter to the collector.

## Syntax (C#)
```csharp
public FilteredElementCollector OfClass(
	Type type
)
```

## Parameters
- **type** (`System.Type`) - The element type.

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
Only elements whose class is an exact match to the input class,
 or elements whose type is derived from the input class will pass the collector.
 There is a small subset of Element subclasses in the API that are not supported
 by this filter. These classes exist in the API, but not in Revit's native object model,
 which means that this filter doesn't support them. In order to use a class filter to
 find elements of these types, it is necessary to use a higher level class and then
 process the results further to find elements matching only the subclass. For a list
 of subclasses affected by this restriction, consult the documentation for ElementClassFilter.
 If you have an active iterator to this collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input type is not a subclass of Element.
 -or-
 The input type is of an element type that exists in the API, but not in Revit's native object model.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

