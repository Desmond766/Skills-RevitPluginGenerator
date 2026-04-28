---
kind: method
id: M:Autodesk.Revit.DB.BoundingBoxIsInsideFilter.#ctor(Autodesk.Revit.DB.Outline)
source: html/bae511fd-a0e0-e44a-c282-e87f537fefb5.htm
---
# Autodesk.Revit.DB.BoundingBoxIsInsideFilter.#ctor Method

Constructs a new instance of a filter to match elements with a bounding box that is contained by the given Outline.

## Syntax (C#)
```csharp
public BoundingBoxIsInsideFilter(
	Outline outline
)
```

## Parameters
- **outline** (`Autodesk.Revit.DB.Outline`) - The Outline used to find elements with a bounding box that are contained by it.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - outline is an empty Outline.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

