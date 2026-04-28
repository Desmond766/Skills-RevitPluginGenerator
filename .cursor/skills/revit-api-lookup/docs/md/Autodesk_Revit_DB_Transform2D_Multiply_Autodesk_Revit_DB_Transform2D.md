---
kind: method
id: M:Autodesk.Revit.DB.Transform2D.Multiply(Autodesk.Revit.DB.Transform2D)
source: html/52de67bf-77eb-6065-c702-589319f3cae5.htm
---
# Autodesk.Revit.DB.Transform2D.Multiply Method

Multiplies this transformation by the specified transformation and returns the result.

## Syntax (C#)
```csharp
public Transform2D Multiply(
	Transform2D right
)
```

## Parameters
- **right** (`Autodesk.Revit.DB.Transform2D`)

## Returns
The transformation equal to the composition of the two transformations.

## Remarks
The combined transformation has the same effect as applying the right transformation first, and this transformation, second.
 So, denoting this transform by T1 and the right transform by T2, (T1(T2(p)) = (T1 * T2) (p).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

