---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DrawContext.FlushBuffer(Autodesk.Revit.DB.DirectContext3D.VertexBuffer,System.Int32,Autodesk.Revit.DB.DirectContext3D.IndexBuffer,System.Int32,Autodesk.Revit.DB.DirectContext3D.VertexFormat,Autodesk.Revit.DB.DirectContext3D.EffectInstance,Autodesk.Revit.DB.DirectContext3D.PrimitiveType,System.Int32,System.Int32)
source: html/e216a4c0-6a88-cf2c-35fa-8f43019db61d.htm
---
# Autodesk.Revit.DB.DirectContext3D.DrawContext.FlushBuffer Method

Submits geometry for rendering.

## Syntax (C#)
```csharp
public static void FlushBuffer(
	VertexBuffer vertexBuffer,
	int vertexCount,
	IndexBuffer indexBuffer,
	int indexCount,
	VertexFormat vertexFormat,
	EffectInstance effectInstance,
	PrimitiveType primitiveType,
	int start,
	int primitiveCount
)
```

## Parameters
- **vertexBuffer** (`Autodesk.Revit.DB.DirectContext3D.VertexBuffer`) - The vertex buffer that contains vertex data.
- **vertexCount** (`System.Int32`) - The number of vertices in the vertex buffer.
- **indexBuffer** (`Autodesk.Revit.DB.DirectContext3D.IndexBuffer`) - The index buffer that contains indices into the vertex buffer.
- **indexCount** (`System.Int32`) - The number of indices in the index buffer.
- **vertexFormat** (`Autodesk.Revit.DB.DirectContext3D.VertexFormat`) - The format of the vertices in the vertex buffer.
- **effectInstance** (`Autodesk.Revit.DB.DirectContext3D.EffectInstance`) - The effect instance to be used for drawing this piece of geometry.
- **primitiveType** (`Autodesk.Revit.DB.DirectContext3D.PrimitiveType`) - The type of geometry primitive used in the index buffer.
- **start** (`System.Int32`) - The first index to use for drawing.
- **primitiveCount** (`System.Int32`) - The number of primitives to draw.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - A change in the graphics state has made the vertex buffer vertexBuffer invalid for rendering.
 -or-
 A change in the graphics state has made the index buffer indexBuffer invalid for rendering.
 -or-
 A change in the graphics state has made the vertex format vertexFormat invalid for rendering.
 -or-
 A change in the graphics state has made the effect instance effectInstance invalid for rendering.
 -or-
 The vertex format vertexFormat and the effect instance effectInstance do not match.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This DrawContext is not available because Revit is not currently rendering. In general, this DrawContext must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

