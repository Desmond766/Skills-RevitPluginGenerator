---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeVertex.Turn
source: html/77147703-c606-28f2-5ebc-01e0f2ddd25d.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeVertex.Turn Property

The sense of the turn. The Turn property must be set to Left or Right on each internal vertex
 before the RebarShapeDefinitionBySegments is used.
 Default is permissible for the first and last vertex, since they do not correspond to bends.

## Syntax (C#)
```csharp
public RebarShapeVertexTurn Turn { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: turn must be Left or Right.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

