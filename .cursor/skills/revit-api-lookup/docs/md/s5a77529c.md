---
kind: method
id: M:Autodesk.Revit.DB.ElementIntersectsElementFilter.#ctor(Autodesk.Revit.DB.Element)
source: html/7e54ea68-559b-b449-1d4f-619c4e07f077.htm
---
# Autodesk.Revit.DB.ElementIntersectsElementFilter.#ctor Method

Constructs a filter to match elements which intersect the given element.

## Syntax (C#)
```csharp
public ElementIntersectsElementFilter(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element to check for intersection.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The category of the element is not supported for element intersection filters.
 -or-
 The element is not supported for element intersection filters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

