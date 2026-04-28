---
kind: method
id: M:Autodesk.Revit.DB.BoundingBoxContainsPointFilter.#ctor(Autodesk.Revit.DB.XYZ,System.Double,System.Boolean)
source: html/d2891b1c-b50c-cadc-addf-9256d44efd12.htm
---
# Autodesk.Revit.DB.BoundingBoxContainsPointFilter.#ctor Method

Constructs a new instance of a filter to match elements with a bounding box that contains the given point,
 while specifying the tolerance to be used in deciding if the point matches the criteria.
 This constructor includes the option to invert the filter and match all elements with a bounding box that do not contain the given point.

## Syntax (C#)
```csharp
public BoundingBoxContainsPointFilter(
	XYZ point,
	double tolerance,
	bool inverted
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point used to find elements with a bounding box containing it.
- **tolerance** (`System.Double`) - The tolerance value to use instead of zero. See the tolerance property for details.
- **inverted** (`System.Boolean`) - True if the filter should be inverted and match all elements with a bounding box that do not contain the given point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for tolerance is not finite
 -or-
 The given value for tolerance is not a number
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

