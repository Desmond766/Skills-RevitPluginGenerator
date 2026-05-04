---
kind: type
id: T:Autodesk.Revit.DB.DirectContext3D.VertexFormatBits
source: html/e993d256-56d3-4103-3451-bb42bc90a7d8.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexFormatBits

Vertex format (i.e., the type of data associated with a vertex) represented as a number.

## Syntax (C#)
```csharp
public enum VertexFormatBits
```

## Remarks
VertexFormatBits can be used to specify the vertex format in the creation of the following objects:
 EffectInstance VertexFormat 
 VertexFormatBits is not to be confused with VertexFormat. The latter type of object is associated with low-level graphics
 functionality and may become invalid. VertexFormat is needed to submit a set of vertex and index buffers for rendering (see
 DrawContext ).

