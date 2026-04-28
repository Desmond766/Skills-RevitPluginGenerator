---
kind: type
id: T:Autodesk.Revit.DB.TriangulatedSolidOrShell
source: html/5c6d36f6-8c0d-1570-07aa-3cabb05b268a.htm
---
# Autodesk.Revit.DB.TriangulatedSolidOrShell

This class represents a triangulated solid or shell.

## Syntax (C#)
```csharp
public class TriangulatedSolidOrShell : IDisposable
```

## Remarks
The triangulation consists of a number of TriangulatedShellComponents.
 For a solid, there will be one TriangulatedShellComponent for each component
 of the solid's boundary. For example, a solid cube has just one boundary component
 (containing six faces), so there will be just one TriangulatedShellComponent. A solid
 consisting of two disjoint cubes has two boundary components (the boundaries of the
 two cubes), so there will be two TriangulatedShellComponents. A solid consisting of a
 sphere with a round void (or hole) inside it also has two boundary components (the
 outer sphere and the inner sphere), so there will be two TriangulatedShellComponents.
 For a shell, there will be one TriangulatedShellComponent for each component of
 the shell.
 Note that this class does not contain information on the containment structure
 of the boundary components of a solid.
 Be careful not to confuse the components of a solid with the solid's
 boundary components. This class deals only with the boundary components.

