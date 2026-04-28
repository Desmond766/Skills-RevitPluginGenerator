---
kind: method
id: M:Autodesk.Revit.DB.Transform.Multiply(Autodesk.Revit.DB.Transform)
zh: 变换
source: html/dca45f2a-e404-765e-4bb8-cf39982bf034.htm
---
# Autodesk.Revit.DB.Transform.Multiply Method

**中文**: 变换

Multiplies this transformation by the specified transformation and returns the result.

## Syntax (C#)
```csharp
public Transform Multiply(
	Transform right
)
```

## Parameters
- **right** (`Autodesk.Revit.DB.Transform`) - The specified transformation.

## Returns
The transformation equal to the composition of the two transformations.

## Remarks
The combined transformation has the same effect as applying the right transformation first, 
and the left transformation, second. So, (T1(T2(p)) = (T1 * T2) (p).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the handle of the specified transformation is Nothing nullptr a null reference ( Nothing in Visual Basic) .

