---
kind: method
id: M:Autodesk.Revit.DB.XYZ.DistanceTo(Autodesk.Revit.DB.XYZ)
zh: 点
source: html/ecbbee02-8f32-d5e9-a565-9c072543ea4f.htm
---
# Autodesk.Revit.DB.XYZ.DistanceTo Method

**中文**: 点

Returns the distance from this point to the specified point.

## Syntax (C#)
```csharp
public double DistanceTo(
	XYZ source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.XYZ`) - The specified point.

## Returns
The real number equal to the distance between the two points.

## Remarks
The distance between the two points is equal to the length of the vector
that joins the two points.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

