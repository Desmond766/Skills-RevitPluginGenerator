---
kind: method
id: M:Autodesk.Revit.DB.XYZ.AngleOnPlaneTo(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 点
source: html/417e2c71-f806-746c-c638-d54d220f8476.htm
---
# Autodesk.Revit.DB.XYZ.AngleOnPlaneTo Method

**中文**: 点

Returns the angle between this vector and the specified vector projected to the specified plane.

## Syntax (C#)
```csharp
public double AngleOnPlaneTo(
	XYZ right,
	XYZ normal
)
```

## Parameters
- **right** (`Autodesk.Revit.DB.XYZ`) - The specified vector.
- **normal** (`Autodesk.Revit.DB.XYZ`) - The normal vector that defines the plane.

## Returns
The real number between 0 and 2*PI equal to the projected angle between the two vectors.

## Remarks
The angle is projected onto the plane orthogonal to the specified normal vector,
counterclockwise with the normal pointing upwards.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when right or normal is Nothing nullptr a null reference ( Nothing in Visual Basic) .

