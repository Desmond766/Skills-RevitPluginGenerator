---
kind: type
id: T:Autodesk.Revit.DB.DirectContext3D.DrawContext
source: html/b9244325-08c8-8bbd-a9f3-5d91d638d85d.htm
---
# Autodesk.Revit.DB.DirectContext3D.DrawContext

A class that provides drawing functionality for use by IDirectContext3DServer servers

## Syntax (C#)
```csharp
public static class DrawContext
```

## Remarks
The drawing facility of this class is conceptually similar to a low-level graphics API.
 The functionality operates on a set of geometry primitives such as triangles, lines, and points, which are encoded into
 a set of vertex and index buffers.
Aside from submission of geometry in buffers, a major part of the drawing process is
 responding to certain changes in graphics state. For example, users of this class can implement progressive rendering
 of geometry by testing whether there have been interruptions that should prevent the drawing from being completed.

