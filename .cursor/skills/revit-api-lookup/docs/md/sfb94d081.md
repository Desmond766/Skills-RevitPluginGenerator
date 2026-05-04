---
kind: type
id: T:Autodesk.Revit.DB.DirectContext3D.VertexPositionNormalColored
source: html/aa354e03-2b25-b5a4-5634-c3518518c0d3.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexPositionNormalColored

A geometry vertex specified as a position in space with a normal vector and a color.

## Syntax (C#)
```csharp
public class VertexPositionNormalColored : Vertex
```

## Remarks
The color of these vertices includes a transparency component
 In order to render them as transparent they must be rendered in the transparent pass
 See the 'IsTransparentPass' method of DrawContext

