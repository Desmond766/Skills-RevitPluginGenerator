---
kind: method
id: M:Autodesk.Revit.DB.Transform2D.PreScale(System.Double)
source: html/c1f6f144-e9a3-0efb-4d1d-2eba05d849f1.htm
---
# Autodesk.Revit.DB.Transform2D.PreScale Method

Scales the linear part of this transformation and returns the result.

## Syntax (C#)
```csharp
public Transform2D PreScale(
	double scale
)
```

## Parameters
- **scale** (`System.Double`) - The scale value.

## Returns
Returns a pointer to "this" Transform2D .

## Remarks
The resulting transformation is equivalent to the application of the uniform scale and then this transformation, in this order.

