---
kind: method
id: M:Autodesk.Revit.DB.XYZ.Subtract(Autodesk.Revit.DB.XYZ)
zh: 点
source: html/2ef3475e-245b-7988-062d-966d213b7863.htm
---
# Autodesk.Revit.DB.XYZ.Subtract Method

**中文**: 点

Subtracts the specified vector from this vector and returns the result.

## Syntax (C#)
```csharp
public XYZ Subtract(
	XYZ source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.XYZ`) - The vector to subtract from this vector.

## Returns
The vector equal to the difference between the two vectors.

## Remarks
The subtracted vector is obtained by subtracting each coordinate of 
the specified vector from the corresponding coordinate of this vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

