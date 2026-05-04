---
kind: method
id: M:Autodesk.Revit.DB.UV.Multiply(System.Double)
source: html/92549142-9d39-893e-27c7-4731084ae726.htm
---
# Autodesk.Revit.DB.UV.Multiply Method

Multiplies this 2-D vector by the specified value and returns the result.

## Syntax (C#)
```csharp
public UV Multiply(
	double value
)
```

## Parameters
- **value** (`System.Double`) - The value to multiply with this vector.

## Returns
The multiplied 2-D vector.

## Remarks
The multiplied vector is obtained by multiplying each coordinate of 
this vector by the specified value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is an infinite number.

