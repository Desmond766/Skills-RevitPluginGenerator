---
kind: method
id: M:Autodesk.Revit.DB.XYZ.IsAlmostEqualTo(Autodesk.Revit.DB.XYZ,System.Double)
zh: 点
source: html/81a72471-bfa6-18ec-db83-911a49c3f4e8.htm
---
# Autodesk.Revit.DB.XYZ.IsAlmostEqualTo Method

**中文**: 点

Determines whether 2 vectors are the same within the given tolerance.

## Syntax (C#)
```csharp
public bool IsAlmostEqualTo(
	XYZ source,
	double tolerance
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.XYZ`) - The vector to compare with this vector.
- **tolerance** (`System.Double`) - The tolerance for equality check.

## Returns
True if the vectors are the same; otherwise, false.

## Remarks
This routine uses an input tolerance to compare two vectors to see if they are almost equivalent. Because it is 
comparing two vectors the tolerance value is not in length units but instead represents the variation in direction 
between the vectors. For very small tolerance values it should also be possible to compare two points
with this method. To compute the distance between two points for a comparison with a larger allowable difference, use
 DistanceTo(XYZ) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when tolerance is less than 0.

