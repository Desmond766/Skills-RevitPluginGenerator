---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetCurves(System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
source: html/8ca32c92-c297-84db-ffdc-8ab2017d6b98.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetCurves Method

Set the curves into a free form Rebar. Will throw exception if the rebar has valid constraints.

## Syntax (C#)
```csharp
public RebarFreeFormValidationResult SetCurves(
	IList<CurveLoop> curves
)
```

## Parameters
- **curves** (`System.Collections.Generic.IList < CurveLoop >`) - Each curve loop represents a bar in the set.

## Returns
Returns Success if everything is ok, otherwise the failure reason.

## Remarks
This function can fail due to following reasons: The array of CurveLoops is empty. At least one CurveLoop is empty. At least one CurveLoop contains an unbounded curve. A rebar constructed from curves can't be bent according to the bending radius.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor Rebar is constrained.

