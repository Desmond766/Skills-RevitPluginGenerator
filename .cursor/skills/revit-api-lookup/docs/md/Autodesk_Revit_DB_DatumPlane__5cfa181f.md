---
kind: type
id: T:Autodesk.Revit.DB.DatumPlane
source: html/3e0a6725-ee40-c4d5-839f-b7720c1fe2af.htm
---
# Autodesk.Revit.DB.DatumPlane

A base class representing a datum surface (level, grid or reference plane) in Autodesk Revit.

## Syntax (C#)
```csharp
public class DatumPlane : Element
```

## Remarks
A DatumPlane represents a 3d surface with finite extents. It can be either a rectangle with arbitrary orientation, or a cylinder
 whose axis is parallel to the project z-axis.
If a datum is visible in a plan or section view, it will be displayed as one or more curves. These curves are determined by the
 intersection of the datum surface with the cut plane of the view. By default, the extents of these curves reflect the 3d extents
 of the datum surface. If the surface is a plane, then the extents represent the projection of the surface onto the cut plane. This
 matters, for example, when viewing a datum plane, really a 3d rectangle, along one of its diagonals. The extents of the curve
 do not vary with the location of the view, because we use the projection of the rectangle and not the actual intersection. If the
 surface is a cylinder, then the extents reflect the actual intersection of the surface with the cut plane.
In addition, the curves that represent a DatumPlane can be modified on a view specific basis. In this case, the ends of the curve no
 longer reflect the 3d extents of the datum.

