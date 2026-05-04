---
kind: method
id: M:Autodesk.Revit.DB.Outline.ContainsOtherOutline(Autodesk.Revit.DB.Outline,System.Double)
source: html/3fd3d671-4127-c849-e684-6b8697aaa778.htm
---
# Autodesk.Revit.DB.Outline.ContainsOtherOutline Method

Determine if this Outline contains another Outline to within tolerance.

## Syntax (C#)
```csharp
public bool ContainsOtherOutline(
	Outline otherOutline,
	double tolerance
)
```

## Parameters
- **otherOutline** (`Autodesk.Revit.DB.Outline`) - The outline to test for containment.
- **tolerance** (`System.Double`) - The tolerance to use when determining whether the point is contained. Defaults to zero.

## Returns
True if this outline contains the given outline, or false otherwise.

## Remarks
If the tolerance is positive, the other Outline may extend the tolerance distance outside of this Outline in each coordinate.
 If the tolerance is negative, the other Outline must lie at least the tolerance distance inside of this Outline in each coordinate to be a match.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

