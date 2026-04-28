---
kind: method
id: M:Autodesk.Revit.DB.ConicalSurface.Create(Autodesk.Revit.DB.Frame,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/fc1bff98-15ce-be6e-5a23-89e20aad9e1d.htm
---
# Autodesk.Revit.DB.ConicalSurface.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a conical surface defined by a local reference frame and a half angle.

## Syntax (C#)
```csharp
public static ConicalSurface Create(
	Frame frameOfReference,
	double halfAngle
)
```

## Parameters
- **frameOfReference** (`Autodesk.Revit.DB.Frame`) - frameOfReference is an orthonormal frame that defines a local coordinate system for the cone.
 Frame.Origin is a point on the cylinder's axis. Frame.BasisZ points along the axis, while Frame.BasisX and Frame.BasisY are orthogonal to the axis. The frame may be either left-handed or right-handed (see Frame.IsRightHanded). Note that
 the "handedness" of the frame does not, by itself, determine the surface's orientation.
- **halfAngle** (`System.Double`) - Cone angle. Must be not 0, lesser than PI/2 and greater than -PI/2.

## Returns
The created ConicalSurface.

## Remarks
The parametric equation of the cone is S(u, v) = Frame.Origin + v*[sin(halfAngle)(cos(u)*Frame.BasisX + sin(u)*Frame.BasisY) + cos(halfAngle)*Frame.BasisZ]
 This implies the following facts:
 Frame.BasisX points from the axis point to the point on the cylinder with coordinates (0, 0). Frame.BasisY points in the direction of the partial derivative dS/du at (0, 0). Frame.BasisZ points in the direction of the partial derivative dS/dv at (0, 0). 
 Only the branch of the cone with v >= 0 should be used.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This Frame object may not be used as a local frame of reference.
 -or-
 The supplied value must be not 0, lesser than PI/2 and greater than -PI/2.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

