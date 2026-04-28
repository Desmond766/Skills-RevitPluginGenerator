---
kind: method
id: M:Autodesk.Revit.DB.XYZ.op_Division(Autodesk.Revit.DB.XYZ,System.Double)
zh: 点
source: html/33091c6f-88ed-1263-33d6-2b0070b24268.htm
---
# Autodesk.Revit.DB.XYZ.op_Division Method

**中文**: 点

Divides the specified vector by the specified value.

## Syntax (C#)
```csharp
public static XYZ operator /(
	XYZ left,
	double value
)
```

## Parameters
- **left** (`Autodesk.Revit.DB.XYZ`) - The value to divide the vector by.
- **value** (`System.Double`) - The vector to divide by the value.

## Returns
The divided vector.

## Remarks
The divided vector is obtained by dividing each coordinate of 
the specified vector by the specified value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified value is an infinite number or zero.

