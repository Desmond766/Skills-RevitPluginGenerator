---
kind: method
id: M:Autodesk.Revit.DB.XYZ.AngleTo(Autodesk.Revit.DB.XYZ)
zh: 点
source: html/4251dd2b-1b48-8b2e-7159-02333cdf39e6.htm
---
# Autodesk.Revit.DB.XYZ.AngleTo Method

**中文**: 点

Returns the angle between this vector and the specified vector.

## Syntax (C#)
```csharp
public double AngleTo(
	XYZ source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.XYZ`) - The specified vector.

## Returns
The real number between 0 and PI equal to the angle between the two vectors in radians..

## Remarks
The angle between the two vectors is measured in the plane spanned by them.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

