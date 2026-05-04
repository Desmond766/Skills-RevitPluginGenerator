---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.IsRectangular(Autodesk.Revit.DB.Plane)
source: html/5a82c7ad-4b6e-a62c-6b0c-7fe790886995.htm
---
# Autodesk.Revit.DB.CurveLoop.IsRectangular Method

Identifies if the curve loop is rectangular with respect to a given projection plane.

## Syntax (C#)
```csharp
public bool IsRectangular(
	Plane plane
)
```

## Parameters
- **plane** (`Autodesk.Revit.DB.Plane`) - The plane to which the curves will be projected to determine if they represent a rectangle.

## Returns
True if the curve loop is rectangular, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

