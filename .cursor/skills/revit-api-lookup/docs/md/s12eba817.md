---
kind: method
id: M:Autodesk.Revit.DB.Line.CreateUnbound(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 线、直线
source: html/133d2d1b-e954-5eba-1175-15e8d9e62d16.htm
---
# Autodesk.Revit.DB.Line.CreateUnbound Method

**中文**: 线、直线

Creates a new instance of an unbound linear curve.

## Syntax (C#)
```csharp
public static Line CreateUnbound(
	XYZ origin,
	XYZ direction
)
```

## Parameters
- **origin** (`Autodesk.Revit.DB.XYZ`) - The origin of the unbound line.
- **direction** (`Autodesk.Revit.DB.XYZ`) - The direction of the unbound line.

## Returns
The new unbound line.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - direction has zero length.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Vector and origin cannot form a proper unbound line.

