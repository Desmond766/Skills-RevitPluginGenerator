---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.IsOpen
source: html/ac68d75b-1fda-28f2-c5b2-01c24ff1b8b8.htm
---
# Autodesk.Revit.DB.CurveLoop.IsOpen Method

Returns whether the curve loop is open or closed, as determined by an internal flag.

## Syntax (C#)
```csharp
public bool IsOpen()
```

## Returns
True if the CurveLoop is marked open, false if marked closed.

## Remarks
Some routines in Revit may set the CurveLoop to be marked "open" or "closed" in spite of the actual geometry of the curves.
 In these special cases, the CurveLoop class does not require that the CurveLoop is correctly marked.

