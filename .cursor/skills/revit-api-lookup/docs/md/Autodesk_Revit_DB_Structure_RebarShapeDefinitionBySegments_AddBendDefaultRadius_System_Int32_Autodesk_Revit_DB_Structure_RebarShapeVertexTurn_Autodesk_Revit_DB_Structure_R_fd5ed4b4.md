---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddBendDefaultRadius(System.Int32,Autodesk.Revit.DB.Structure.RebarShapeVertexTurn,Autodesk.Revit.DB.Structure.RebarShapeBendAngle)
source: html/499ff7f9-94f4-e341-d169-84b6561a46a8.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddBendDefaultRadius Method

Specify a default-radius bend.

## Syntax (C#)
```csharp
public void AddBendDefaultRadius(
	int vertexIndex,
	RebarShapeVertexTurn turn,
	RebarShapeBendAngle angle
)
```

## Parameters
- **vertexIndex** (`System.Int32`) - Index of the vertex (1 to NumberOfVertices - 2).
- **turn** (`Autodesk.Revit.DB.Structure.RebarShapeVertexTurn`) - Specify turn direction (RebarShapeVertexTurn::Left or RebarShapeVertexTurn::Right).
- **angle** (`Autodesk.Revit.DB.Structure.RebarShapeBendAngle`) - Specify whether the bend is acute, obtuse, etc.

## Remarks
You must add a bend at each vertex except the first and last.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - vertexIndex is not between 0 and NumberOfVertices.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

