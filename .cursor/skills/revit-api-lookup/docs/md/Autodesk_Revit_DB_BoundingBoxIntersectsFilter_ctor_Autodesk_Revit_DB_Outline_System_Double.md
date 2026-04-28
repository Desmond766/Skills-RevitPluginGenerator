---
kind: method
id: M:Autodesk.Revit.DB.BoundingBoxIntersectsFilter.#ctor(Autodesk.Revit.DB.Outline,System.Double)
source: html/12de85f3-3aa7-fcb9-eda1-7744b052e442.htm
---
# Autodesk.Revit.DB.BoundingBoxIntersectsFilter.#ctor Method

Constructs a new instance of a filter to match elements with a bounding box that intersects the given Outline.

## Syntax (C#)
```csharp
public BoundingBoxIntersectsFilter(
	Outline outline,
	double tolerance
)
```

## Parameters
- **outline** (`Autodesk.Revit.DB.Outline`) - The Outline used to find elements with a bounding box that intersect it.
- **tolerance** (`System.Double`) - The tolerance value to use instead of zero. See the tolerance property for details.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - outline is an empty Outline.
 -or-
 The given value for tolerance is not finite
 -or-
 The given value for tolerance is not a number
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

