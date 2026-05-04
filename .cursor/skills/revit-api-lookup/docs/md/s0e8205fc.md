---
kind: method
id: M:Autodesk.Revit.DB.Plane.Create(Autodesk.Revit.DB.Frame)
zh: 创建、新建、生成、建立、新增
source: html/38aeacdd-59c5-7741-2802-6de25838130f.htm
---
# Autodesk.Revit.DB.Plane.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a Plane object defined by a local frame of reference.

## Syntax (C#)
```csharp
public static Plane Create(
	Frame frameOfReference
)
```

## Parameters
- **frameOfReference** (`Autodesk.Revit.DB.Frame`) - frameOfReference is an orthonormal frame that defines a local coordinate system for the plane being constructed.
 Frame.Origin is a point on plane. Frame.BasisZ defines the plane's normal, while Frame.BasisX and Frame.BasisY are orthogonal to the normal. The frame may be either left-handed or right-handed (see Frame.IsRightHanded).

## Remarks
The parametric equation of the plane is S(u, v) = Frame.Origin + u*Frame.BasisX + v*Frame.BasisY. Frame.BasisZ defines the plane's normal.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This Frame object may not be used as a local frame of reference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

