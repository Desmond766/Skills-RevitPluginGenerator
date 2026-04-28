---
kind: method
id: M:Autodesk.Revit.DB.XYZ.DotProduct(Autodesk.Revit.DB.XYZ)
zh: 点
source: html/63e0ee6c-b612-7140-7805-d32c10f7a8bc.htm
---
# Autodesk.Revit.DB.XYZ.DotProduct Method

**中文**: 点

The dot product of this vector and the specified vector.

## Syntax (C#)
```csharp
public double DotProduct(
	XYZ source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.XYZ`) - The vector to multiply with this vector.

## Returns
The real number equal to the dot product.

## Remarks
The dot product is the sum of the respective coordinates of the two vectors: 
Vx*Wx + Vy*Wy + Vz*Wz. Also known as scalar product or inner product.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

