---
kind: method
id: M:Autodesk.Revit.DB.Transform.ScaleBasisAndOrigin(System.Double)
zh: 变换
source: html/460caa53-d288-7cfe-dbb8-eadf4682329d.htm
---
# Autodesk.Revit.DB.Transform.ScaleBasisAndOrigin Method

**中文**: 变换

Scales the basis vectors and the origin of this transformation and returns the result.

## Syntax (C#)
```csharp
public Transform ScaleBasisAndOrigin(
	double scale
)
```

## Parameters
- **scale** (`System.Double`) - The scale value.

## Returns
The transformation equal to the composition of the two transformations.

## Remarks
The resulting transformation is equivalent to the application of this transformation
and then the uniform scale, in this order.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is an infinite number.

