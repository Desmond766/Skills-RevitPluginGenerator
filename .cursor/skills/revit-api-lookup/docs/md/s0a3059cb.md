---
kind: type
id: T:Autodesk.Revit.DB.DirectContext3D.EffectInstance
source: html/45b7ef37-46b6-6cf4-2f42-c6f4055a170c.htm
---
# Autodesk.Revit.DB.DirectContext3D.EffectInstance

An effect instance that controls the appearance of geometry.

## Syntax (C#)
```csharp
public class EffectInstance : IDisposable
```

## Remarks
Each effect instance should be used with geometry of a matching vertex format. Only a subset of effect instance
 parameters is relevant to geometry of a particular vertex format.
 If the vertex format does not specify vertex color
 ( VertexPosition or VertexPositionNormal )
 the following parameters should be set:
 Color Transparency 
 If the vertex format specifies vertex normals
 ( VertexPositionNormal or VertexPositionNormalColored )
 the following parameters should be set:
 Ambient Color Diffuse Color Specular Color Glossiness (specular exponent) EmissiveColor Transparency 
 If the vertex format specifies a color, then the geometry will be colored according to the color of each
 vertex. Otherwise, the geometry's color will come from the effect instance parameters. Similarly, the transparency parameter
 affects all of the geometry associated with the effect, while the transparency of the individual vertices can also
 be controlled via the transparency component of their colors.

