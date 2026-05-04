---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalOpening.IsCurveLoopValidForAnalyticalOpening(Autodesk.Revit.DB.CurveLoop,Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/8d7e3d44-e9d5-02bd-9d33-8a3924165e0f.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalOpening.IsCurveLoopValidForAnalyticalOpening Method

Checks if curve loop is valid for Analytical Opening.

## Syntax (C#)
```csharp
public static bool IsCurveLoopValidForAnalyticalOpening(
	CurveLoop loop,
	Document aDoc,
	ElementId panelId
)
```

## Parameters
- **loop** (`Autodesk.Revit.DB.CurveLoop`) - The curve loop to be checked.
- **aDoc** (`Autodesk.Revit.DB.Document`) - Revit document.
- **panelId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the AnalyticalPanel on which we create the Opening.

## Returns
Returns true if curve loop is ok, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

