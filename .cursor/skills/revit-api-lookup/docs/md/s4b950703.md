---
kind: method
id: M:Autodesk.Revit.DB.RevolvedSurface.Create(Autodesk.Revit.DB.Frame,Autodesk.Revit.DB.Curve,System.Double,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/f3e8c800-d92d-d09a-17ba-212d7ebf3b59.htm
---
# Autodesk.Revit.DB.RevolvedSurface.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a Surface object coincident with the surface of revolution defined by a coordinate frame, a profile curve,
 and start and end angles of revolution.

## Syntax (C#)
```csharp
public static Surface Create(
	Frame frameOfReference,
	Curve profileCurve,
	double startAngle,
	double endAngle
)
```

## Parameters
- **frameOfReference** (`Autodesk.Revit.DB.Frame`) - frameOfReference is an orthonormal frame that defines a local coordinate system for the surface of revolution.
 The frame can be "right-handed" or "left-handed". The origin of the frame is the base of point of the axis of revolution. The BasisZ of the frame is the direction of the axis.
- **profileCurve** (`Autodesk.Revit.DB.Curve`) - The profile curve, which should satisfy the following conditions:
 It is bounded and non-degenerate. It is co-planar with the axis of revolution. It lies on the xz plane of the frame. It lies on the right side of the axis. Only the end points of the profile curve can touch the axis.
- **startAngle** (`System.Double`) - Start angle of rotation.
 The angles are measured around the axis of revolution, using the right-hand rule.
 The profile curve is at the zero angle.
- **endAngle** (`System.Double`) - End angle of rotation.
 Start angle must be less than end angle and their difference must be less than or equal to two times PI.

## Returns
The created surface. Note that this surface may not be of type RevolvedSurface.

## Remarks
The returned surface may not be of type RevolvedSurface - this function will create a surface of the simplest possible
 type (Plane, Cylinder, etc.) that can be used to represent the required surface of revolution.
 Given that the surface may be simplified, this function does not guarantee any particular parameterization of the surface.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This Frame object may not be used as a local frame of reference.
 -or-
 The input profile curve is not valid to create a surface revolution in the given frame.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Start angle must be less than end angle and their difference must be less than or equal to two times PI.

