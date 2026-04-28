---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.EffectInstance.#ctor(Autodesk.Revit.DB.DirectContext3D.VertexFormatBits)
source: html/35aedbef-870d-ca83-5810-be60c60ee08c.htm
---
# Autodesk.Revit.DB.DirectContext3D.EffectInstance.#ctor Method

Constructs the effect instance for geometry having the specified vertex format.

## Syntax (C#)
```csharp
public EffectInstance(
	VertexFormatBits vertexFormatBits
)
```

## Parameters
- **vertexFormatBits** (`Autodesk.Revit.DB.DirectContext3D.VertexFormatBits`) - The vertex format of the geometry to be used with this effect instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This EffectInstance is not available because Revit is not currently rendering. In general, this EffectInstance must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

