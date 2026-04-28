---
kind: method
id: M:Autodesk.Revit.DB.MultiSegmentGrid.IsValidCurveLoop(Autodesk.Revit.DB.CurveLoop)
source: html/cc8ce9f7-9dc9-a807-76c1-f4bfb12232b9.htm
---
# Autodesk.Revit.DB.MultiSegmentGrid.IsValidCurveLoop Method

Identifies whether the specified curve loop is valid for creation of a MultiSegmentGrid.

## Syntax (C#)
```csharp
public static bool IsValidCurveLoop(
	CurveLoop curveLoop
)
```

## Parameters
- **curveLoop** (`Autodesk.Revit.DB.CurveLoop`) - The curve loop.

## Returns
True if the curve loop is an open curve loop consisting of lines and arcs, and false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

