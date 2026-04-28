---
kind: method
id: M:Autodesk.Revit.DB.XYZ.IsAlmostEqualTo(Autodesk.Revit.DB.XYZ)
zh: 点
source: html/72feac6d-3f77-10ea-8ba8-087ab43e76b2.htm
---
# Autodesk.Revit.DB.XYZ.IsAlmostEqualTo Method

**中文**: 点

Determines whether this vector and the specified vector are the same within the tolerance (1.0e-09).

## Syntax (C#)
```csharp
public bool IsAlmostEqualTo(
	XYZ source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.XYZ`) - The vector to compare with this vector.

## Returns
True if the vectors are the same; otherwise, false.

## Remarks
This routine uses Revit's default tolerance to compare two vectors to see if they are almost equivalent. 
Because the tolerance is small enough this can also be used to compare two points.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .

