---
kind: method
id: M:Autodesk.Revit.DB.Arc.Create(Autodesk.Revit.DB.XYZ,System.Double,System.Double,System.Double,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/bb8e759b-a0a6-ce55-59df-529f228d5c06.htm
---
# Autodesk.Revit.DB.Arc.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new geometric arc object based on center, radius, unit vectors, and angles.

## Syntax (C#)
```csharp
public static Arc Create(
	XYZ center,
	double radius,
	double startAngle,
	double endAngle,
	XYZ xAxis,
	XYZ yAxis
)
```

## Parameters
- **center** (`Autodesk.Revit.DB.XYZ`) - The center of the arc.
- **radius** (`System.Double`) - The radius of the arc.
- **startAngle** (`System.Double`) - The start angle of the arc (in radians).
- **endAngle** (`System.Double`) - The end angle of the arc (in radians).
- **xAxis** (`Autodesk.Revit.DB.XYZ`) - The x axis to define the arc plane. Must be normalized.
- **yAxis** (`Autodesk.Revit.DB.XYZ`) - The y axis to define the arc plane. Must be normalized.

## Returns
The new arc.

## Remarks
If the angle range is equal to or greater than 2 * PI, the curve will be
 automatically converted to an unbounded circle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - xAxis is not length 1.0.
 -or-
 yAxis is not length 1.0.
 -or-
 The given value for radius must be between 0 and 30000 feet.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The vectors xAxis and yAxis are not perpendicular.
 -or-
 Start angle must be less than end angle.
 -or-
 Curve length is too small for Revit's tolerance (as identified by Application.ShortCurveTolerance).

