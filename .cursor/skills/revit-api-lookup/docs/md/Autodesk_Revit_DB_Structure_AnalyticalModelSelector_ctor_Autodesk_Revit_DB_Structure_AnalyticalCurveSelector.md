---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalModelSelector.#ctor(Autodesk.Revit.DB.Structure.AnalyticalCurveSelector)
source: html/a54cd767-e7b3-019c-d8f9-8122fbb53d07.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalModelSelector.#ctor Method

Creates a selector for the analytical model geometry.

## Syntax (C#)
```csharp
public AnalyticalModelSelector(
	AnalyticalCurveSelector inCurveSelector
)
```

## Parameters
- **inCurveSelector** (`Autodesk.Revit.DB.Structure.AnalyticalCurveSelector`) - Portion of the analytical curve in which the client has interest.

## Remarks
This version is useful for single-curve or single-point analytical models.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

