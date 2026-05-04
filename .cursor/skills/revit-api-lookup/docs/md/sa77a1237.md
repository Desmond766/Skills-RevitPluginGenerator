---
kind: method
id: M:Autodesk.Revit.DB.Structure.LineLoad.IsCurveInsideHostBoundaries(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Curve)
source: html/4bdb0447-3312-6ce7-08a6-f9a8de84ab3e.htm
---
# Autodesk.Revit.DB.Structure.LineLoad.IsCurveInsideHostBoundaries Method

Indicates if the curve is inside panel's boundaries or on panel's edges or if the curve is on the member's curve.

## Syntax (C#)
```csharp
public static bool IsCurveInsideHostBoundaries(
	Document doc,
	ElementId hostId,
	Curve curve
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document containing both the host and the line load.
- **hostId** (`Autodesk.Revit.DB.ElementId`) - The id of the analytical element that is about to host a line load.
- **curve** (`Autodesk.Revit.DB.Curve`) - Curve to be checked.

## Returns
True if a line load can be placed on the input host id

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

