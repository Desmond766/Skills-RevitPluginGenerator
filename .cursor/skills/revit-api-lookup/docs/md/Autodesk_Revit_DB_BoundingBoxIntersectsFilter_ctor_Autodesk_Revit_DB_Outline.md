---
kind: method
id: M:Autodesk.Revit.DB.BoundingBoxIntersectsFilter.#ctor(Autodesk.Revit.DB.Outline)
source: html/3a1c089f-082f-e0f6-fc80-68a3c60db8ef.htm
---
# Autodesk.Revit.DB.BoundingBoxIntersectsFilter.#ctor Method

Constructs a new instance of a filter to match elements with a bounding box that intersects the given Outline.

## Syntax (C#)
```csharp
public BoundingBoxIntersectsFilter(
	Outline outline
)
```

## Parameters
- **outline** (`Autodesk.Revit.DB.Outline`) - The Outline used to find elements with a bounding box that intersect it.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - outline is an empty Outline.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

