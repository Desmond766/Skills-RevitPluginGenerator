---
kind: method
id: M:Autodesk.Revit.DB.Transform.AlmostEqual(Autodesk.Revit.DB.Transform)
zh: 变换
source: html/91717709-a62e-9880-527e-d52a9a0ae048.htm
---
# Autodesk.Revit.DB.Transform.AlmostEqual Method

**中文**: 变换

Determines whether this transformation and the specified transformation are the same within the tolerance (1.0e-09).

## Syntax (C#)
```csharp
public bool AlmostEqual(
	Transform right
)
```

## Parameters
- **right** (`Autodesk.Revit.DB.Transform`) - The transformation to compare with this transformation.

## Returns
True if the two transformations are equal; otherwise, false.

## Remarks
The tolerance is applied memberwise for comparison.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the specified transformation is Nothing nullptr a null reference ( Nothing in Visual Basic) .

