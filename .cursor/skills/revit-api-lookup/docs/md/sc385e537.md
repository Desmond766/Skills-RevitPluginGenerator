---
kind: method
id: M:Autodesk.Revit.DB.UV.AngleTo(Autodesk.Revit.DB.UV)
source: html/38893def-a134-5659-3c05-a20db60488fa.htm
---
# Autodesk.Revit.DB.UV.AngleTo Method

Returns the angle between this vector and the specified vector.

## Syntax (C#)
```csharp
public double AngleTo(
	UV source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.UV`) - The specified vector.

## Returns
The real number between 0 and 2*PI equal to the angle between the two vectors in radians.

## Remarks
The angle is measured counterclockwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

