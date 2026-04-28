---
kind: type
id: T:Autodesk.Revit.DB.ElementIntersectsSolidFilter
source: html/19276b94-fa39-64bb-bfb8-c16967c83485.htm
---
# Autodesk.Revit.DB.ElementIntersectsSolidFilter

A filter to find elements that intersect the given solid geometry.

## Syntax (C#)
```csharp
public class ElementIntersectsSolidFilter : ElementIntersectsFilter
```

## Remarks
The input solid used for this filter can be obtained from an existing element, created from scratch
 using the routines in GeometryCreationUtilities or builder classes, or the generated from the result of a
 secondary operation such as a Boolean operation. Similar to the ElementIntersectsElementFilter ,
 this filter will not detect as intersecting elements which lack solid geometry, such as Rebar. This filter is a slow filter.
 Slow filters require that the Element be obtained and expanded in memory first.
 Thus it is preferable to couple this filter with at least one ElementQuickFilter,
 which should minimize the number of Elements that are expanded.

