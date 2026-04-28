---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeConstraintSegmentLength.GetSegmentEndReferenceType(System.Int32)
source: html/4265b167-adda-c808-f378-3de1571e216b.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeConstraintSegmentLength.GetSegmentEndReferenceType Method

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

