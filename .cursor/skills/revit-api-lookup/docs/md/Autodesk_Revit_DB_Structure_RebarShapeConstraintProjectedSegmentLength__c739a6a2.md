---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarShapeConstraintProjectedSegmentLength
source: html/a41486b4-25c4-c955-f1ab-c585ffb92bd2.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintProjectedSegmentLength

A constraint that measures the length of a segment as measured by projecting onto a direction
 that is not parallel to the segment.

## Syntax (C#)
```csharp
public class RebarShapeConstraintProjectedSegmentLength : RebarShapeConstraint
```

## Remarks
The constraint has two references, indexed by 0 and 1, that do not have to
 correspond to the start and end of the segment. The constraint also specifies
 a direction as a 2D vector, which is not necessarily parallel to the segment,
 but must point from the segment's start toward its end.

