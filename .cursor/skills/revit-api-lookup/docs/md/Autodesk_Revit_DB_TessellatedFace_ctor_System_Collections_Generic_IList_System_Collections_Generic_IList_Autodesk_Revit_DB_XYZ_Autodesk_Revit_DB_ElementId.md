---
kind: method
id: M:Autodesk.Revit.DB.TessellatedFace.#ctor(System.Collections.Generic.IList{System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ}},Autodesk.Revit.DB.ElementId)
source: html/b8dcecf2-a4a8-8517-6735-f253e5e203b9.htm
---
# Autodesk.Revit.DB.TessellatedFace.#ctor Method

Constructs a tessellated face, which, may be, have holes. Face data
 is always set, even if the input data are invalid (e.g., describes
 a wildly non-planar face). A TessellatedShepeBuilder's function is
 used to check the data and heal them if possible.

## Syntax (C#)
```csharp
public TessellatedFace(
	IList<IList<XYZ>> allLoopVertices,
	ElementId materialId
)
```

## Parameters
- **allLoopVertices** (`System.Collections.Generic.IList < IList < XYZ >>`) - Boundary vertices without duplication of the ends - i.e., a
 boundary of a triangular face consists of 3 (and NOT 4) vertices.
 The first array describes the outer loop, the following arrays,
 if any - inner loops.
 It is expected that vertices of outer boundary are listed in CCW
 order with respect to the face normal in the solid, while the
 vertices of inner loops - in CW order. The vertices listed in the
 wrong order will still be handled by TessellatedShapeBuilder, but
 performance may deteriorate. Contents of this parameter will be
 changed while constructing the face.
- **materialId** (`Autodesk.Revit.DB.ElementId`) - Material of the face to be used when the result is a Solid or a Sheet.
 If the result is a Mesh, a material will be assigned to the entire Mesh.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

