---
kind: method
id: M:Autodesk.Revit.DB.ElementIntersectsElementFilter.#ctor(Autodesk.Revit.DB.Element,System.Boolean)
source: html/d9d50a3c-d6e1-4693-1762-1298da8f0c6a.htm
---
# Autodesk.Revit.DB.ElementIntersectsElementFilter.#ctor Method

Constructs a filter to match elements which intersect the given element, with the
 option to match all elements not intersecting the given element.

## Syntax (C#)
```csharp
public ElementIntersectsElementFilter(
	Element element,
	bool inverted
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element to check for intersection.
- **inverted** (`System.Boolean`) - True if the filter should match all elements which do not intersect the given
 element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The category of the element is not supported for element intersection filters.
 -or-
 The element is not supported for element intersection filters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

