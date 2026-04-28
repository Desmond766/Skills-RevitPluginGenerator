---
kind: method
id: M:Autodesk.Revit.DB.RevolvedSurface.IsValidProfileCurve(Autodesk.Revit.DB.Frame,Autodesk.Revit.DB.Curve)
source: html/b0b32fa1-32f7-22bd-a4ae-f62aa777b4c8.htm
---
# Autodesk.Revit.DB.RevolvedSurface.IsValidProfileCurve Method

Checks if the input profile curve is valid to create a surface of revolution in the given frame of reference.

## Syntax (C#)
```csharp
public static bool IsValidProfileCurve(
	Frame frameOfReference,
	Curve profileCurve
)
```

## Parameters
- **frameOfReference** (`Autodesk.Revit.DB.Frame`) - frameOfReference is an orthonormal frame that defines a local coordinate system for the surface of revolution.
 The frame can be "right-handed" or "left-handed". The origin of the frame is the base of point of the axis of revolution. The BasisZ of the frame is the direction of the axis.
- **profileCurve** (`Autodesk.Revit.DB.Curve`) - The profile curve.

## Returns
True if the profile curve is valid; False otherwise.

## Remarks
The validity is defined as follows:
 The profile curve is bounded and non-degenerate. It is co-planar with the axis of revolution. It lies on the xz plane of the frame. It lies on the right side of the axis. Only the end points of the profile curve can touch the axis.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

