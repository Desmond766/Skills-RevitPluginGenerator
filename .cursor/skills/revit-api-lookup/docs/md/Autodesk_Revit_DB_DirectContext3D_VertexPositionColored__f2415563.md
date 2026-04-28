---
kind: type
id: T:Autodesk.Revit.DB.DirectContext3D.VertexPositionColored
source: html/f99deacd-3167-46ff-6abf-5d27bdbd2c6a.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexPositionColored

A geometry vertex specified as a position in space with a color.

## Syntax (C#)
```csharp
public class VertexPositionColored : Vertex
```

## Remarks
The color of these vertices includes a transparency component
 In order to render them as transparent they must be rendered in the transparent pass
 See the 'IsTransparentPass' method of DrawContext

