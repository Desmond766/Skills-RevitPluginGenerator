---
kind: method
id: M:Autodesk.Revit.DB.GeometryElement.GetBoundingBox
source: html/2f8676a8-5b07-cbd7-e364-826719ab97ca.htm
---
# Autodesk.Revit.DB.GeometryElement.GetBoundingBox Method

Retrieves a box that encloses the geometry element.

## Syntax (C#)
```csharp
public BoundingBoxXYZ GetBoundingBox()
```

## Returns
The bounding box.

## Remarks
Note: If the GeometryElement was obtained via Element.get_Geometry from an Element containing 2D geometry
but no 3D geometry, the bounding box returned by this function may not be empty because it takes the 2D geometry into account.

