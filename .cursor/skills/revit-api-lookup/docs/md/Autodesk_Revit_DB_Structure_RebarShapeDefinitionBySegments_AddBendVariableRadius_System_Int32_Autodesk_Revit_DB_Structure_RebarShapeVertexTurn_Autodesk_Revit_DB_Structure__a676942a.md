---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddBendVariableRadius(System.Int32,Autodesk.Revit.DB.Structure.RebarShapeVertexTurn,Autodesk.Revit.DB.Structure.RebarShapeBendAngle,Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/0a54d7c6-4951-e153-faba-b46dadb5c5c1.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments.AddBendVariableRadius Method

Specify a variable-radius bend.

## Syntax (C#)
```csharp
public void AddBendVariableRadius(
	int vertexIndex,
	RebarShapeVertexTurn turn,
	RebarShapeBendAngle angle,
	ElementId paramId,
	bool measureIncludingBarThickness
)
```

## Parameters
- **vertexIndex** (`System.Int32`) - Index of the vertex (1 to NumberOfVertices - 2).
- **turn** (`Autodesk.Revit.DB.Structure.RebarShapeVertexTurn`) - Specify turn direction (RebarShapeVertexTurn::Left or RebarShapeVertexTurn::Right).
- **angle** (`Autodesk.Revit.DB.Structure.RebarShapeBendAngle`) - Specify whether the bend is acute, obtuse, etc.
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter driving the radius.
- **measureIncludingBarThickness** (`System.Boolean`) - If true, the radius is measured to the outside of the
 bend; if false, it is measured to the inside.

## Remarks
You must add a bend between each two segments.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - vertexIndex is not between 0 and NumberOfVertices.
 -or-
 paramId is not the id of a shared parameter in the current document,
 or its unit type is not UT_Reinforcement_Length or UT_Angle.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

