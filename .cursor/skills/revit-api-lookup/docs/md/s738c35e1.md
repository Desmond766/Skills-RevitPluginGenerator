---
kind: method
id: M:Autodesk.Revit.DB.UV.Subtract(Autodesk.Revit.DB.UV)
source: html/794663ba-4332-4bfc-f77c-d371f6af69bf.htm
---
# Autodesk.Revit.DB.UV.Subtract Method

Subtracts the specified 2-D vector from this 2-D vector and returns the result.

## Syntax (C#)
```csharp
public UV Subtract(
	UV source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.UV`) - The vector to subtract from this vector.

## Returns
The 2-D vector equal to the difference between the two vectors.

## Remarks
The subtracted vector is obtained by subtracting each coordinate of 
the specified vector from the corresponding coordinate of this vector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when left is Nothing nullptr a null reference ( Nothing in Visual Basic) .

