---
kind: method
id: M:Autodesk.Revit.DB.UV.DotProduct(Autodesk.Revit.DB.UV)
source: html/34a57c43-f0f8-213d-5f44-c2504170de15.htm
---
# Autodesk.Revit.DB.UV.DotProduct Method

The dot product of this 2-D vector and the specified 2-D vector.

## Syntax (C#)
```csharp
public double DotProduct(
	UV source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.UV`) - The vector to multiply with this vector.

## Returns
The real number equal to the dot product.

## Remarks
The dot product is the sum of the respective coordinates of the two vectors: Pu * Ru + Pv * Rv.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

