---
kind: method
id: M:Autodesk.Revit.DB.XYZ.TripleProduct(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 点
source: html/d6e9b965-f5ed-60c2-2575-ac2999e76eb5.htm
---
# Autodesk.Revit.DB.XYZ.TripleProduct Method

**中文**: 点

The triple product of this vector and the two specified vectors.

## Syntax (C#)
```csharp
public double TripleProduct(
	XYZ middle,
	XYZ right
)
```

## Parameters
- **middle** (`Autodesk.Revit.DB.XYZ`) - The second vector.
- **right** (`Autodesk.Revit.DB.XYZ`) - The third vector.

## Returns
The real number equal to the triple product.

## Remarks
The scalar triple product is defined as the dot product of one of the vectors 
with the cross product of the other two. Geometrically, this product is the (signed) 
volume of the parallelepiped formed by the three vectors given.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when middle or right is Nothing nullptr a null reference ( Nothing in Visual Basic) .

