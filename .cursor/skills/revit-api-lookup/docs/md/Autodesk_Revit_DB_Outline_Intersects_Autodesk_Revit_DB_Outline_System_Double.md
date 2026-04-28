---
kind: method
id: M:Autodesk.Revit.DB.Outline.Intersects(Autodesk.Revit.DB.Outline,System.Double)
source: html/2c32184b-515c-7597-335b-17f44435b7ab.htm
---
# Autodesk.Revit.DB.Outline.Intersects Method

Determine if this Outline intersects the input Outline to within a specified tolerance.

## Syntax (C#)
```csharp
public bool Intersects(
	Outline outline,
	double tolerance
)
```

## Parameters
- **outline** (`Autodesk.Revit.DB.Outline`) - The outline to test for intersection with this one.
- **tolerance** (`System.Double`) - The tolerance to use when determining intersection. Defaults to zero.

## Returns
True if the given outline intersects this outline.

## Remarks
If the tolerance is positive, the outlines may be separated by the tolerance distance in each coordinate.
 If the tolerance is negative, the outlines must overlap by at least the tolerance distance in each coordinate.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

