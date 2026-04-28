---
kind: method
id: M:Autodesk.Revit.DB.UV.op_Multiply(System.Double,Autodesk.Revit.DB.UV)
source: html/8753ebe5-e03a-31f3-31a1-0da7473abb58.htm
---
# Autodesk.Revit.DB.UV.op_Multiply Method

The product of the specified number and the specified 2-D vector.

## Syntax (C#)
```csharp
public static UV operator *(
	double value,
	UV right
)
```

## Parameters
- **value** (`System.Double`) - The value to multiply with the specified vector.
- **right** (`Autodesk.Revit.DB.UV`) - The vector to multiply with the value.

## Returns
The multiplied 2-D vector.

## Remarks
The multiplied vector is obtained by multiplying each coordinate of 
the specified vector by the specified value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is an infinite number.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when right is Nothing nullptr a null reference ( Nothing in Visual Basic) .

