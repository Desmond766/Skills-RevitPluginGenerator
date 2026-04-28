---
kind: method
id: M:Autodesk.Revit.DB.XYZ.op_Subtraction(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 点
source: html/bc4fdb82-362f-864d-beb4-2292091ec49c.htm
---
# Autodesk.Revit.DB.XYZ.op_Subtraction Method

**中文**: 点

Subtracts the two specified vectors and returns the result.

## Syntax (C#)
```csharp
public static XYZ operator -(
	XYZ left,
	XYZ right
)
```

## Parameters
- **left** (`Autodesk.Revit.DB.XYZ`) - The first vector.
- **right** (`Autodesk.Revit.DB.XYZ`) - The second vector.

## Returns
The vector equal to the difference between the two source vectors.

## Remarks
The subtracted vector is obtained by subtracting each coordinate of 
the right vector from the corresponding coordinate of the left vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when left or right is Nothing nullptr a null reference ( Nothing in Visual Basic) .

