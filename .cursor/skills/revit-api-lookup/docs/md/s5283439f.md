---
kind: type
id: T:Autodesk.Revit.DB.TriangulationInterfaceForTriangulatedSolidOrShell
source: html/f47c4054-827d-3f5e-adce-bcd8e93ac090.htm
---
# Autodesk.Revit.DB.TriangulationInterfaceForTriangulatedSolidOrShell

This class is used to call FacetingUtils::convertTrianglesToQuads with a triangulation defined
 by a TriangulatedSolidOrShell.

## Syntax (C#)
```csharp
public class TriangulationInterfaceForTriangulatedSolidOrShell : TriangulationInterface
```

## Remarks
The vertex and triangle indices used by this class treat the triangulated solid or shell as if all
 the vertices and triangles of the different shell components were collected into single sets of vertices
 and triangles, respectively. For example, if a solid has two shell components and the first has ten vertices
 while the second has five vertices, vertexIndex 6 refers to vertex[6] of the first shell component, and
 vertexIndex 12 refers to vertex[2] of the second shell component. You can use the class
 TriangulationInterfaceForTriangulatedShellComponent to get a faceting of an individual shell component.

