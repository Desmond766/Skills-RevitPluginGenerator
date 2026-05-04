---
kind: method
id: M:Autodesk.Revit.DB.XYZ.op_Multiply(Autodesk.Revit.DB.XYZ,System.Double)
zh: 点
source: html/f86834d9-8bc4-3f1d-0032-ca9d9d5cd5a6.htm
---
# Autodesk.Revit.DB.XYZ.op_Multiply Method

**中文**: 点

Multiplies the specified number and the specified vector.

## Syntax (C#)
```csharp
public static XYZ operator *(
	XYZ left,
	double value
)
```

## Parameters
- **left** (`Autodesk.Revit.DB.XYZ`) - The vector to multiply with the value.
- **value** (`System.Double`) - The value to multiply with the specified vector.

## Returns
The multiplied vector.

## Remarks
The multiplied vector is obtained by multiplying each coordinate of 
the specified vector by the specified value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is an infinite number.

