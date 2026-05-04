---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalModelSelector.#ctor(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.Structure.AnalyticalCurveSelector)
source: html/844652b6-c1ca-395f-21fc-a9bea3aff457.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalModelSelector.#ctor Method

Creates a selector based on one portion of a specific analytical curve.

## Syntax (C#)
```csharp
public AnalyticalModelSelector(
	Curve curve,
	AnalyticalCurveSelector inCurveSelector
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The curve upon which this selector acts.
- **inCurveSelector** (`Autodesk.Revit.DB.Structure.AnalyticalCurveSelector`) - Portion of the analytical curve in which the client is interested.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve points to a helical curve and is not supported for this operation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

