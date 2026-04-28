---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarTrimExtendData.AddBarGeometry(System.Collections.Generic.IList{Autodesk.Revit.DB.Curve})
source: html/674f12da-e4a0-fc7f-b011-a706c7859d40.htm
---
# Autodesk.Revit.DB.Structure.RebarTrimExtendData.AddBarGeometry Method

Adds a new rebar geometry. This information is set to the rebar after the API execution is finished successfully.

## Syntax (C#)
```csharp
public RebarFreeFormValidationResult AddBarGeometry(
	IList<Curve> curves
)
```

## Parameters
- **curves** (`System.Collections.Generic.IList < Curve >`) - Curves describing one bar in the set.

## Returns
Returns Success if everything is ok, otherwise the failure reason.

## Remarks
This function will can fail due to following reasons: One or more of the input curves was null. One or more of the input curves was unbounded. Curves doesn't form a valid curve loop, it forms 0, 2 or more curve loops. A rebar constructed from curves can't be bent according to the bending radius.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Incorrect number of bar geometry.

