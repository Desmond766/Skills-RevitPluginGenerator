---
kind: method
id: M:Autodesk.Revit.DB.ElementIntersectsSolidFilter.#ctor(Autodesk.Revit.DB.Solid,System.Boolean)
source: html/d0762dd5-1e9e-2453-0f40-5e109748f989.htm
---
# Autodesk.Revit.DB.ElementIntersectsSolidFilter.#ctor Method

Constructs a filter to match elements which intersect the given element, with the
 option to match all elements not intersecting the given element.

## Syntax (C#)
```csharp
public ElementIntersectsSolidFilter(
	Solid solid,
	bool inverted
)
```

## Parameters
- **solid** (`Autodesk.Revit.DB.Solid`) - The solid geometry to check for intersection.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which do not intersect the given
 element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

