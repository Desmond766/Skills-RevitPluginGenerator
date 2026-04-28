---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.AddFace(Autodesk.Revit.DB.BRepBuilderSurfaceGeometry,System.Boolean)
source: html/cb899f6d-c4e0-0983-ab70-bae0a620dc8d.htm
---
# Autodesk.Revit.DB.BRepBuilder.AddFace Method

Creates an empty face in the geometry being built. Other BRepBuilder methods are used to add loops to the face.

## Syntax (C#)
```csharp
public BRepBuilderGeometryId AddFace(
	BRepBuilderSurfaceGeometry surfaceGeom,
	bool bFaceIsReversed
)
```

## Parameters
- **surfaceGeom** (`Autodesk.Revit.DB.BRepBuilderSurfaceGeometry`) - The face's support surface.
- **bFaceIsReversed** (`System.Boolean`) - True if the face's orientation is opposite to that of the surface, false if the orientations agree.
 The faces of each shell must be consistently oriented. For a solid (BRepType == Solid), the oriented face normals
 must point out of the solid; for a void (BRepType == Void), the face normals must point into the void.
 See the description of the bCoEdgeIsReversed input for AddCoEdge() for a discussion of the loop and co-edge orientation conventions
 to use with the BRepBuilder.

## Returns
An id that can be used to identify the face while the BRepBuilder is actively building geometry (e.g., to add a loop to a face).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This BRepBuilder object isn't accepting new data, either because it has already been used to build geometry, or because of an error.
 Consult the State property of the BRepBuilder object for more details.

