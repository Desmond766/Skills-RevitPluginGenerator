---
kind: method
id: M:Autodesk.Revit.DB.XYZ.op_Multiply(System.Double,Autodesk.Revit.DB.XYZ)
zh: 点
source: html/4fd3fab2-424f-907b-b3b9-6507eebb2e5a.htm
---
# Autodesk.Revit.DB.XYZ.op_Multiply Method

**中文**: 点

Multiplies the specified number and the specified vector.

## Syntax (C#)
```csharp
public static XYZ operator *(
	double value,
	XYZ right
)
```

## Parameters
- **value** (`System.Double`) - The value to multiply with the specified vector.
- **right** (`Autodesk.Revit.DB.XYZ`) - The vector to multiply with the value.

## Returns
The multiplied vector.

## Remarks
The multiplied vector is obtained by multiplying each coordinate of 
the specified vector by the specified value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when right is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is an infinite number.

