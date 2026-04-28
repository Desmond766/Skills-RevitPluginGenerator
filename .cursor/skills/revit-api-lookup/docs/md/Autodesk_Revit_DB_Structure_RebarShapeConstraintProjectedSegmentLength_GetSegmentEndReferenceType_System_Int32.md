---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraintProjectedSegmentLength.GetSegmentEndReferenceType(System.Int32)
source: html/b97eb2c5-4cbc-6229-e0c6-968037f007ff.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintProjectedSegmentLength.GetSegmentEndReferenceType Method

Choice of two possibilities for the start and end references of the length constraint.

## Syntax (C#)
```csharp
public RebarShapeSegmentEndReferenceType GetSegmentEndReferenceType(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - Which reference on the constraint. Either 0 or 1.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is not 0 or 1.

