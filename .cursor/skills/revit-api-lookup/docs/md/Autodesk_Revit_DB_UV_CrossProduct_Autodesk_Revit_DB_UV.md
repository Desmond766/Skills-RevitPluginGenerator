---
kind: method
id: M:Autodesk.Revit.DB.UV.CrossProduct(Autodesk.Revit.DB.UV)
source: html/408566a0-0940-d038-5bf4-c69e2b5b02a1.htm
---
# Autodesk.Revit.DB.UV.CrossProduct Method

The cross product of this 2-D vector and the specified 2-D vector.

## Syntax (C#)
```csharp
public double CrossProduct(
	UV source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.UV`) - The vector to multiply with this vector.

## Returns
The real number equal to the cross product.

## Remarks
The cross product of the two vectors in 2-D space is equivalent to the area of the parallelogram they span.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

