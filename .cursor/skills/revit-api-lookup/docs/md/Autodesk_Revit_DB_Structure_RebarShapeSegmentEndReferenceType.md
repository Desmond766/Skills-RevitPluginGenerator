---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarShapeSegmentEndReferenceType
source: html/92c3fafa-996d-cca9-cc7e-a73d4c94ae57.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeSegmentEndReferenceType

A choice of two reference points for one end of a constraint driving the length of
 a RebarShapeSegment.

## Syntax (C#)
```csharp
public enum RebarShapeSegmentEndReferenceType
```

## Remarks
The RebarShapeSegmentEndReferenceType of a constraint is meaningful only
 when the bend is
 right or
 obtuse .
 If the bend is
 acute ,
 the reference type is ignored.

