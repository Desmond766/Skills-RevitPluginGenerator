---
kind: method
id: M:Autodesk.Revit.DB.XYZ.op_Addition(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 点
source: html/e19b0989-f628-ba42-a67e-7e3cad42df4c.htm
---
# Autodesk.Revit.DB.XYZ.op_Addition Method

**中文**: 点

Adds the two specified vectors and returns the result.

## Syntax (C#)
```csharp
public static XYZ operator +(
	XYZ left,
	XYZ right
)
```

## Parameters
- **left** (`Autodesk.Revit.DB.XYZ`) - The first vector.
- **right** (`Autodesk.Revit.DB.XYZ`) - The second vector.

## Returns
The vector equal to the sum of the two source vectors.

## Remarks
The added vector is obtained by adding each coordinate of the right vector
to the corresponding coordinate of the left vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when left or right is Nothing nullptr a null reference ( Nothing in Visual Basic) .

