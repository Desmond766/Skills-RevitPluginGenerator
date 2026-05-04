---
kind: type
id: T:Autodesk.Revit.DB.ElementIntersectsElementFilter
source: html/404df79f-2e48-ad4d-2654-a49aa5bf4443.htm
---
# Autodesk.Revit.DB.ElementIntersectsElementFilter

A filter to find elements that intersect the solid geometry of a given element.

## Syntax (C#)
```csharp
public class ElementIntersectsElementFilter : ElementIntersectsFilter
```

## Remarks
The target object is another element. The intersection is determined with the same logic used by Revit
 to determine if an interference exists during generation of an Interference Report. (This means that some
 combinations of elements will never be detected as intersecting by this filter, such as concrete members which are automatically
 joined at their intersections). Also, elements which have no solid geometry, such as Rebar, will never be detected
 as intersecting by this filter. This filter is a slow filter.
 Slow filters require that the Element be obtained and expanded in memory first.
 Thus it is preferable to couple this filter with at least one ElementQuickFilter,
 which should minimize the number of Elements that are expanded.

