---
kind: method
id: M:Autodesk.Revit.DB.BoundingBoxIsInsideFilter.#ctor(Autodesk.Revit.DB.Outline,System.Double)
source: html/a24232ff-a589-6b30-1cd7-a57bfe1a9daf.htm
---
# Autodesk.Revit.DB.BoundingBoxIsInsideFilter.#ctor Method

Constructs a new instance of a filter to match elements with a bounding box that is contained by the given Outline.

## Syntax (C#)
```csharp
public BoundingBoxIsInsideFilter(
	Outline outline,
	double tolerance
)
```

## Parameters
- **outline** (`Autodesk.Revit.DB.Outline`) - The Outline used to find elements with a bounding box that are contained by it.
- **tolerance** (`System.Double`) - The tolerance value to use instead of zero. See the tolerance property for details.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - outline is an empty Outline.
 -or-
 The given value for tolerance is not finite
 -or-
 The given value for tolerance is not a number
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

