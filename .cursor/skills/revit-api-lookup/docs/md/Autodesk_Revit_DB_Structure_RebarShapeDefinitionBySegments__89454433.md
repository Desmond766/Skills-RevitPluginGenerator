---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments
source: html/7229fdba-1e8f-6cb7-e72e-0933e495ad62.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinitionBySegments

Definition of a shape in terms of one or more straight segments of rebar,
 with arc bends between the segments.

## Syntax (C#)
```csharp
public class RebarShapeDefinitionBySegments : RebarShapeDefinition
```

## Remarks
The segments are represented by RebarShapeSegment objects.
 The segments are numbered starting with 0, and they have a direction;
 so the beginning of the shape is end 0 of segment 0, and the end of the
 shape is end 1 of segment (NumberOfSegments-1).
The ends and junctions are represented by RebarShapeVertex objects.
 The number of vertices is always one greater than the number of segments.
 The first vertex represents the start of the shape; the last
 vertex represents the end of the shape; and the intermediate
 vertices represent the bends between segments.

