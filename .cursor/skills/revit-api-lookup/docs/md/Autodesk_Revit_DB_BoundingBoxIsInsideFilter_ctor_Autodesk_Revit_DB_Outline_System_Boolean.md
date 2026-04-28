---
kind: method
id: M:Autodesk.Revit.DB.BoundingBoxIsInsideFilter.#ctor(Autodesk.Revit.DB.Outline,System.Boolean)
source: html/37839e5d-fbbc-7026-5727-d1464970dbee.htm
---
# Autodesk.Revit.DB.BoundingBoxIsInsideFilter.#ctor Method

Constructs a new instance of a filter to match elements with a bounding box is contained by the given Outline,
 with the option to invert the filter and match all elements with a bounding box that are not contained by the given Outline.

## Syntax (C#)
```csharp
public BoundingBoxIsInsideFilter(
	Outline outline,
	bool inverted
)
```

## Parameters
- **outline** (`Autodesk.Revit.DB.Outline`) - The Outline used to find elements with a bounding box that are contained by it.
- **inverted** (`System.Boolean`) - True if the filter should be inverted and match all elements with a bounding box that are not contained by the given Outline.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - outline is an empty Outline.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

