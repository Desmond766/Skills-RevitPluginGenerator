---
kind: method
id: M:Autodesk.Revit.DB.Transform2D.AlmostEqual(Autodesk.Revit.DB.Transform2D)
source: html/149b3851-ba79-c3fa-591e-33496f053962.htm
---
# Autodesk.Revit.DB.Transform2D.AlmostEqual Method

Determines whether this transformation and the specified transformation are the same within the tolerance (1.0e-09).

## Syntax (C#)
```csharp
public bool AlmostEqual(
	Transform2D right
)
```

## Parameters
- **right** (`Autodesk.Revit.DB.Transform2D`) - The transformation to compare with this transformation.

## Returns
True if the two transformations are equal, false otherwise.

## Remarks
The tolerance is applied memberwise for comparison.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

