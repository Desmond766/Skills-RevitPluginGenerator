---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarShapeSegment
source: html/4fd9ba08-b5a3-39c8-9666-fc0a105615c6.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeSegment

Part of a RebarShapeDefinitionBySegments, representing one segment
 of a shape definition.
 Makes sure constraints of type RebarShapeConstraintFixedSegmentDir are uniquely set.
 If we try to aquire a second constraint of type RebarShapeConstraintFixedSegmentDir we delete the old one.

## Syntax (C#)
```csharp
public class RebarShapeSegment : IDisposable
```

## Remarks
Each segment must have enough constraints
 to determine its position. Overconstraining is allowed.
 The most common combinations are:
 A fixed direction together with a parallel length constraint; A parallel length constraint plus another length constraint parallel to the x-axis or y-axis; A parallel length constraint plus length constraints parallel to both the x-axis and y-axis. 
 Multiple constraints may be driven by the same parameter, even on the same segment.
Length constraints may be measured in two ways.
 For "measured to the outside of the bend," the reference is a tangent to the
 exterior face of the bar; the thickness of the bar is included.
 For "measured to the inside," the reference is the center of the arc of the bend;
 this is the point where the bend begins, if the constraint is parallel to the segment.
A 180-degree bend is described by introducing a short segment in between the
 two straight segments, tangent to the midpoint of the bend.

