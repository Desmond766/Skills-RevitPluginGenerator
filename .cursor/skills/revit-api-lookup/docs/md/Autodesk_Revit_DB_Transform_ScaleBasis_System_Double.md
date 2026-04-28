---
kind: method
id: M:Autodesk.Revit.DB.Transform.ScaleBasis(System.Double)
zh: 变换
source: html/35360886-77c5-4117-e395-b83b95f9c884.htm
---
# Autodesk.Revit.DB.Transform.ScaleBasis Method

**中文**: 变换

Scales the basis vectors of this transformation and returns the result.

## Syntax (C#)
```csharp
public Transform ScaleBasis(
	double scale
)
```

## Parameters
- **scale** (`System.Double`) - The scale value.

## Returns
The transformation equal to the composition of the two transformations.

## Remarks
The resulting transformation is equivalent to the application of the uniform scale
and then this transformation, in this order.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is an infinite number.

