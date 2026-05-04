---
kind: method
id: M:Autodesk.Revit.DB.Edge.TessellateOnFace(Autodesk.Revit.DB.Face)
source: html/559bef1b-1423-e732-1219-ee50c85b82f5.htm
---
# Autodesk.Revit.DB.Edge.TessellateOnFace Method

Returns a polyline approximation to the edge in UV parameters of the face.

## Syntax (C#)
```csharp
public IList<UV> TessellateOnFace(
	Face face
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Face`) - The face on which to perform the tessellation. Must belong to the edge.

## Remarks
Tolerance of approximation is defined internally by Revit to be adequate for
display purposes.

