---
kind: method
id: M:Autodesk.Revit.DB.XYZ.Multiply(System.Double)
zh: 点
source: html/81e7b833-bed9-f797-e4ad-9e6df4b0cc12.htm
---
# Autodesk.Revit.DB.XYZ.Multiply Method

**中文**: 点

Multiplies this vector by the specified value and returns the result.

## Syntax (C#)
```csharp
public XYZ Multiply(
	double value
)
```

## Parameters
- **value** (`System.Double`) - The value to multiply with this vector.

## Returns
The multiplied vector.

## Remarks
The multiplied vector is obtained by multiplying each coordinate of 
this vector by the specified value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is an infinite number.

