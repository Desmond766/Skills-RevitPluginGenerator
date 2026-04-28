---
kind: method
id: M:Autodesk.Revit.DB.Edge.EvaluateOnFace(System.Double,Autodesk.Revit.DB.Face)
source: html/1ade3356-8405-4d06-f004-79fc11026786.htm
---
# Autodesk.Revit.DB.Edge.EvaluateOnFace Method

Evaluates a parameter on the edge to produce UV coordinates on the face.

## Syntax (C#)
```csharp
public UV EvaluateOnFace(
	double param,
	Face face
)
```

## Parameters
- **param** (`System.Double`) - The parameter to be evaluated, in [0,1].
- **face** (`Autodesk.Revit.DB.Face`) - The face on which to perform the evaluation. Must belong to the edge.

