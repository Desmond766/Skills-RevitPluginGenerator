---
kind: method
id: M:Autodesk.Revit.DB.Transform1D.OfVector(System.Double)
source: html/9d1500f3-b374-791a-c4e0-d2a2cbfcba44.htm
---
# Autodesk.Revit.DB.Transform1D.OfVector Method

Applies the transformation to the 1-dimensional vector (a "tangent vector" on the real line) and returns the result.

## Syntax (C#)
```csharp
public double OfVector(
	double vector
)
```

## Parameters
- **vector** (`System.Double`) - The vector to transform.

## Returns
The transformed vector.

## Remarks
Transformation of a vector is not affected by the translational part of the transformation.

