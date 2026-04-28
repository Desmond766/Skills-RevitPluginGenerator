---
kind: method
id: M:Autodesk.Revit.DB.BoundingBoxContainsPointFilter.#ctor(Autodesk.Revit.DB.XYZ,System.Boolean)
source: html/349bf4ad-de49-f6fe-f223-6d782b70570f.htm
---
# Autodesk.Revit.DB.BoundingBoxContainsPointFilter.#ctor Method

Constructs a new instance of a filter to match elements with a bounding box that contains the given point,
 with the option to invert the filter and match all elements with a bounding box that do not contain the given point.

## Syntax (C#)
```csharp
public BoundingBoxContainsPointFilter(
	XYZ point,
	bool inverted
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point used to find elements with a bounding box containing it.
- **inverted** (`System.Boolean`) - True if the filter should be inverted and match all elements with a bounding box that do not contain the given point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

