---
kind: method
id: M:Autodesk.Revit.DB.CylindricalSurface.Create(Autodesk.Revit.DB.Frame,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/ae360b1d-65c3-2991-62c7-13193f5792e5.htm
---
# Autodesk.Revit.DB.CylindricalSurface.Create Method

**中文**: 创建、新建、生成、建立、新增

Construct a cylindrical surface defined by a local coordinate system and a radius.

## Syntax (C#)
```csharp
public static CylindricalSurface Create(
	Frame frameOfReference,
	double radius
)
```

## Parameters
- **frameOfReference** (`Autodesk.Revit.DB.Frame`) - frameOfReference is an orthonormal frame that defines a local coordinate system for the cylinder.
 Frame.Origin is a point on the cylinder's axis. Frame.BasisZ points along the axis, while Frame.BasisX and Frame.BasisY are orthogonal to the axis. The frame may be either left-handed or right-handed (see Frame.IsRightHanded). Note that
 the "handedness" of the frame does not, by itself, determine the surface's orientation.
- **radius** (`System.Double`) - Radius of the circle that defines the base of the cylindrical surface.

## Returns
The created CylindricalSurface.

## Remarks
The parametric equation of the cylinder is S(u, v) = Frame.Origin + radius*cos(u)*Frame.BasisX + radius*sin(u)*Frame.BasisY + v*Frame.BasisZ.
 This implies the following facts:
 Frame.BasisX points from the axis point to the point on the cylinder with coordinates (0, 0). Frame.BasisY points in the direction of the partial derivative dS/du at (0, 0). Frame.BasisZ points in the direction of the partial derivative dS/dv at (0, 0).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This Frame object may not be used as a local frame of reference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for radius must be greater than 0 and no more than 30000 feet.

