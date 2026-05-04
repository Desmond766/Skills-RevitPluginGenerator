---
kind: method
id: M:Autodesk.Revit.DB.Arc.Create(Autodesk.Revit.DB.Plane,System.Double,System.Double,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/e609576e-3266-3c0e-f9db-7b04636be542.htm
---
# Autodesk.Revit.DB.Arc.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new geometric arc object based on plane, radius, and angles.

## Syntax (C#)
```csharp
public static Arc Create(
	Plane plane,
	double radius,
	double startAngle,
	double endAngle
)
```

## Parameters
- **plane** (`Autodesk.Revit.DB.Plane`) - The plane which the arc resides. The plane's origin is the center of the arc.
- **radius** (`System.Double`) - The radius of the arc.
- **startAngle** (`System.Double`) - The start angle of the arc (in radians).
- **endAngle** (`System.Double`) - The end angle of the arc (in radians).

## Returns
The new arc.

## Remarks
If the angle range is equal to or greater than 2 * PI, the curve will be
 automatically converted to an unbounded circle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for radius must be greater than 0 and no more than 30000 feet.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Start angle must be less than end angle.
 -or-
 Curve length is too small for Revit's tolerance (as identified by Application.ShortCurveTolerance).

