---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarTrimExtendData.AddBarGeometry(Autodesk.Revit.DB.CurveLoop)
source: html/9948f497-0cdc-b3b6-a465-b7fe4e843da2.htm
---
# Autodesk.Revit.DB.Structure.RebarTrimExtendData.AddBarGeometry Method

Adds a new rebar geometry. This information is set to the rebar after the API execution is finished successfully.

## Syntax (C#)
```csharp
public RebarFreeFormValidationResult AddBarGeometry(
	CurveLoop curves
)
```

## Parameters
- **curves** (`Autodesk.Revit.DB.CurveLoop`) - Curves describing one bar in the set.

## Returns
Returns Success if everything is ok, otherwise the failure reason.

## Remarks
This function can fail due to following reasons: CurveLoop is empty. CurveLoop contains an unbounded curve. A rebar constructed from curves can't be bent according to the bending radius.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Incorrect number of bar geometry.

