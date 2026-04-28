---
kind: method
id: M:Autodesk.Revit.DB.BoundingBoxContainsPointFilter.#ctor(Autodesk.Revit.DB.XYZ,System.Double)
source: html/2d8feb9b-f5db-35b7-fef7-98c9ed0c5cce.htm
---
# Autodesk.Revit.DB.BoundingBoxContainsPointFilter.#ctor Method

Constructs a new instance of a filter to match elements with a bounding box that contains the given point,
 while specifying the tolerance to be used in deciding if the point matches the criteria.

## Syntax (C#)
```csharp
public BoundingBoxContainsPointFilter(
	XYZ point,
	double tolerance
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point used to find elements with a bounding box that contains it.
- **tolerance** (`System.Double`) - The tolerance value to use instead of zero. See the tolerance property for details.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for tolerance is not finite
 -or-
 The given value for tolerance is not a number
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

