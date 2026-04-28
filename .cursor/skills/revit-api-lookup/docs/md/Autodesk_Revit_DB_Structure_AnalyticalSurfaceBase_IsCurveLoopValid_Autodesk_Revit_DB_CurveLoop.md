---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalSurfaceBase.IsCurveLoopValid(Autodesk.Revit.DB.CurveLoop)
source: html/4ddc5605-f34f-9c11-bce6-181de75031c8.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalSurfaceBase.IsCurveLoopValid Method

Checks if curve loop is valid for Analytical Panel.

## Syntax (C#)
```csharp
public static bool IsCurveLoopValid(
	CurveLoop profile
)
```

## Parameters
- **profile** (`Autodesk.Revit.DB.CurveLoop`) - The curve loop to be checked.

## Returns
Returns true if curve loop is ok, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

