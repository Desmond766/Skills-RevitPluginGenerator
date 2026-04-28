---
kind: method
id: M:Autodesk.Revit.DB.UV.op_Multiply(Autodesk.Revit.DB.UV,System.Double)
source: html/b2dadbe9-910a-f16b-61ef-b1a8a26bba57.htm
---
# Autodesk.Revit.DB.UV.op_Multiply Method

The product of the specified number and the specified 2-D vector.

## Syntax (C#)
```csharp
public static UV operator *(
	UV left,
	double value
)
```

## Parameters
- **left** (`Autodesk.Revit.DB.UV`) - The vector to multiply with the value.
- **value** (`System.Double`) - The value to multiply with the specified vector.

## Returns
The multiplied 2-D vector.

## Remarks
The multiplied vector is obtained by multiplying each coordinate of 
the specified vector by the specified value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is an infinite number.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when left is Nothing nullptr a null reference ( Nothing in Visual Basic) .

