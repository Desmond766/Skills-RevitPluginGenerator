---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.EffectInstance.MatchesFormat(Autodesk.Revit.DB.DirectContext3D.VertexFormat)
source: html/a7cd2cff-48df-cf5d-bd49-83acb319a438.htm
---
# Autodesk.Revit.DB.DirectContext3D.EffectInstance.MatchesFormat Method

Tests whether the effect instance is appropriate for the given vertex format.

## Syntax (C#)
```csharp
public bool MatchesFormat(
	VertexFormat vertexFormat
)
```

## Parameters
- **vertexFormat** (`Autodesk.Revit.DB.DirectContext3D.VertexFormat`) - A vertex format.

## Returns
True if the effect instance is valid for use with the specified vertex format.

## Remarks
The vertex format may define vertex data that are not used by the effect instance. However, the effect
 instance can not reference vertex data that do not exist in the vertex format.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

