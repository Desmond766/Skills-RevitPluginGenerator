---
kind: method
id: M:Autodesk.Revit.DB.BoundingBoxIntersectsFilter.#ctor(Autodesk.Revit.DB.Outline,System.Boolean)
source: html/608e7bd7-432c-9b73-de4f-d17d8aa6cce3.htm
---
# Autodesk.Revit.DB.BoundingBoxIntersectsFilter.#ctor Method

Constructs a new instance of a filter to match elements with a bounding box that intersects the given Outline,
 with the option to invert the filter and match all elements with a bounding box that are not intersecting the given Outline.

## Syntax (C#)
```csharp
public BoundingBoxIntersectsFilter(
	Outline outline,
	bool inverted
)
```

## Parameters
- **outline** (`Autodesk.Revit.DB.Outline`) - The Outline used to find elements with a bounding box that intersect it.
- **inverted** (`System.Boolean`) - True if the filter should be inverted and match all elements with a bounding box that are not intersecting the given Outline.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - outline is an empty Outline.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

