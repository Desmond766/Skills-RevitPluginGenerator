---
kind: method
id: M:Autodesk.Revit.DB.TessellatedFace.#ctor(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},Autodesk.Revit.DB.ElementId)
source: html/762318a9-e737-8ef1-578b-5be176d28624.htm
---
# Autodesk.Revit.DB.TessellatedFace.#ctor Method

Constructs a tessellated face without holes. Face data is always set,
 even if the input data are invalid (e.g., describes a wildly non-planar
 face). A TessellatedShepeBuilder's function is used to check
 the data and heal them if possible.

## Syntax (C#)
```csharp
public TessellatedFace(
	IList<XYZ> outerLoopVertices,
	ElementId materialId
)
```

## Parameters
- **outerLoopVertices** (`System.Collections.Generic.IList < XYZ >`) - Boundary vertices without duplication of the ends - i.e., a
 boundary of a triangular face consists of 3 (and NOT 4) vertices.
 It is expected that boundaries are in CCW order with respect to
 the face normal in the solid. Boundaries in CW order will still
 be handled by TessellatedShapeBuilder, but performance may
 deteriorate. Contents of this parameter will be changed while
 constructing the face.
- **materialId** (`Autodesk.Revit.DB.ElementId`) - Material of the face to be used when the result is a Solid or a Sheet.
 If the result is a Mesh, a material will be assigned to the entire Mesh.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

