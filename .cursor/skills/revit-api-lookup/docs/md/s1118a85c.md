---
kind: method
id: M:Autodesk.Revit.DB.BoundingBoxIntersectsFilter.#ctor(Autodesk.Revit.DB.Outline,System.Double,System.Boolean)
source: html/be97c617-d4b7-54d8-545e-a3fd9647f73c.htm
---
# Autodesk.Revit.DB.BoundingBoxIntersectsFilter.#ctor Method

Constructs a new instance of a filter to match elements with a bounding box that intersects the given Outline,
 with the option to invert the filter and match all elements with a bounding box that are not intersecting the given Outline.

## Syntax (C#)
```csharp
public BoundingBoxIntersectsFilter(
	Outline outline,
	double tolerance,
	bool inverted
)
```

## Parameters
- **outline** (`Autodesk.Revit.DB.Outline`) - The Outline used to find elements with a bounding box that intersect it.
- **tolerance** (`System.Double`) - The tolerance value to use instead of zero. See the tolerance property for details.
- **inverted** (`System.Boolean`) - True if the filter should be inverted and match all elements with a bounding box that are not intersecting the given Outline.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - outline is an empty Outline.
 -or-
 The given value for tolerance is not finite
 -or-
 The given value for tolerance is not a number
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

