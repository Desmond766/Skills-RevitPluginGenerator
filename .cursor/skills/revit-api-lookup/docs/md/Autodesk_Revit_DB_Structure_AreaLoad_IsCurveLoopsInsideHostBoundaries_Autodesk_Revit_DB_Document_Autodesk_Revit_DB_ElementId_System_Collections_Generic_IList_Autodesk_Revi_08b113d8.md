---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaLoad.IsCurveLoopsInsideHostBoundaries(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
source: html/56f7aaed-c85f-b5ae-07ca-a49eae4efb94.htm
---
# Autodesk.Revit.DB.Structure.AreaLoad.IsCurveLoopsInsideHostBoundaries Method

Checks if contour loops is inside host boundaries.

## Syntax (C#)
```csharp
public static bool IsCurveLoopsInsideHostBoundaries(
	Document doc,
	ElementId hostId,
	IList<CurveLoop> loops
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - Document.
- **hostId** (`Autodesk.Revit.DB.ElementId`) - The id of the analytical element that is about to host a load
- **loops** (`System.Collections.Generic.IList < CurveLoop >`) - CurveLoops to be checked.

## Returns
Returns true if area load is positioned with entire distribution over the host, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

