---
kind: type
id: T:Autodesk.Revit.DB.DirectContext3D.IndexTriangle
source: html/96cdfb77-c6e0-7866-c1f7-799f3dda0ad5.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexTriangle

A triangle primitive consisting of three indices.

## Syntax (C#)
```csharp
public class IndexTriangle : IndexPrimitive
```

## Remarks
Indices of a triangle's vertices can be listed in either the clockwise or counterclockwise winding order,
 according to the triangle's orientation in space. A DirectContext3D triangle faces the viewer if its vertices
 are in counterclockwise order from the viewer's point of view.

