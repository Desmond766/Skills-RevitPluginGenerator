---
kind: method
id: M:Autodesk.Revit.DB.UV.op_Division(Autodesk.Revit.DB.UV,System.Double)
source: html/f75ed7b6-c306-3c72-cb34-4af4bf2cb831.htm
---
# Autodesk.Revit.DB.UV.op_Division Method

Divides the specified 2-D vector by the specified value.

## Syntax (C#)
```csharp
public static UV operator /(
	UV left,
	double value
)
```

## Parameters
- **left** (`Autodesk.Revit.DB.UV`) - The value to divide the vector by.
- **value** (`System.Double`) - The vector to divide by the value.

## Returns
The divided 2-D vector.

## Remarks
The divided vector is obtained by dividing each coordinate of 
the specified vector by the specified value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is an infinite number or zero.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when left is Nothing nullptr a null reference ( Nothing in Visual Basic) .

