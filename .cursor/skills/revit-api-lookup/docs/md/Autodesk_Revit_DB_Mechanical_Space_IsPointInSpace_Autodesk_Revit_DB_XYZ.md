---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.Space.IsPointInSpace(Autodesk.Revit.DB.XYZ)
source: html/33c97031-a9ad-00d0-4d4a-42522201d2db.htm
---
# Autodesk.Revit.DB.Mechanical.Space.IsPointInSpace Method

Determines if a point lies within the volume of the Space.

## Syntax (C#)
```csharp
public bool IsPointInSpace(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - Point to be checked.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the point is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - The coordinates of the point is not a number.

