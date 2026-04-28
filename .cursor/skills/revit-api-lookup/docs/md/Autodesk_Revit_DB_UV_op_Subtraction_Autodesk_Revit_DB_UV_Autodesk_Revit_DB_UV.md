---
kind: method
id: M:Autodesk.Revit.DB.UV.op_Subtraction(Autodesk.Revit.DB.UV,Autodesk.Revit.DB.UV)
source: html/8a02ba52-44be-cdf1-5051-66a1aaf3c656.htm
---
# Autodesk.Revit.DB.UV.op_Subtraction Method

Subtracts the two specified 2-D vectors and returns the result.

## Syntax (C#)
```csharp
public static UV operator -(
	UV left,
	UV right
)
```

## Parameters
- **left** (`Autodesk.Revit.DB.UV`) - The first vector.
- **right** (`Autodesk.Revit.DB.UV`) - The second vector.

## Returns
The 2-D vector equal to the difference between the two source vectors.

## Remarks
The subtracted vector is obtained by subtracting each coordinate of 
the right vector from the corresponding coordinate of the left vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when left or right is Nothing nullptr a null reference ( Nothing in Visual Basic) .

