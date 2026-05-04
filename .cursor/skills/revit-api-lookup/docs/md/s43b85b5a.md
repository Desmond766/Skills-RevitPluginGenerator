---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexFormat.#ctor(Autodesk.Revit.DB.DirectContext3D.VertexFormatBits)
source: html/693bb238-07bc-0b84-a652-37a86fed06ec.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexFormat.#ctor Method

Constructs the specification of vertex format from a numerical representation.

## Syntax (C#)
```csharp
public VertexFormat(
	VertexFormatBits vertexFormatBits
)
```

## Parameters
- **vertexFormatBits** (`Autodesk.Revit.DB.DirectContext3D.VertexFormatBits`) - The numerical representation of the vertex format.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This VertexFormat is not available because Revit is not currently rendering. In general, this VertexFormat must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

