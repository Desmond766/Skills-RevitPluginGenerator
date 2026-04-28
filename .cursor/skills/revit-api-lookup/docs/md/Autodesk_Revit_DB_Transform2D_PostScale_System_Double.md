---
kind: method
id: M:Autodesk.Revit.DB.Transform2D.PostScale(System.Double)
source: html/4bd89ff0-75cf-f499-e88e-9ff5aaff27fd.htm
---
# Autodesk.Revit.DB.Transform2D.PostScale Method

Scales both the linear and translational parts of this transformation and returns the result.

## Syntax (C#)
```csharp
public Transform2D PostScale(
	double scale
)
```

## Parameters
- **scale** (`System.Double`) - The scale value.

## Returns
Returns a pointer to "this" Transform2D .

## Remarks
The resulting transformation is equivalent to the application of this transformation and then the uniform scale, in this order.

