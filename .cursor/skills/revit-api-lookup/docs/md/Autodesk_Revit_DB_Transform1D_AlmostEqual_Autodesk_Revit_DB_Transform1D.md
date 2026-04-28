---
kind: method
id: M:Autodesk.Revit.DB.Transform1D.AlmostEqual(Autodesk.Revit.DB.Transform1D)
source: html/01045a3f-bb71-32d1-ed8b-34c81548344f.htm
---
# Autodesk.Revit.DB.Transform1D.AlmostEqual Method

Determines whether this transformation and the specified transformation are the same within the tolerance (1.0e-09).

## Syntax (C#)
```csharp
public bool AlmostEqual(
	Transform1D right
)
```

## Parameters
- **right** (`Autodesk.Revit.DB.Transform1D`) - The transformation to compare with this transformation.

## Returns
True if the two transformations are equal, false otherwise.

## Remarks
The tolerance is applied memberwise for comparison.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

