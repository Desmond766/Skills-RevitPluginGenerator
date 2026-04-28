---
kind: type
id: T:Autodesk.Revit.DB.TriangulatedShellComponent
source: html/d3883d3e-bacf-6896-fb01-96d0dafe266c.htm
---
# Autodesk.Revit.DB.TriangulatedShellComponent

This class represents a triangulated boundary component of a solid or a
 triangulated connected component of a shell.

## Syntax (C#)
```csharp
public class TriangulatedShellComponent : IDisposable
```

## Remarks
The triangulation is "topologically connected" in the following sense:
 if two triangles share an edge geometrically, then they share a single edge
 topologically (i.e., they share two vertices defining the geometrically shared
 edge).

