---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetCurves(System.Collections.Generic.IList{System.Collections.Generic.IList{Autodesk.Revit.DB.Curve}})
source: html/475f2655-9de8-66d5-441a-63b1e001452f.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetCurves Method

Set the curves into a free form Rebar. Will throw exception if the rebar has valid constraints.

## Syntax (C#)
```csharp
public RebarFreeFormValidationResult SetCurves(
	IList<IList<Curve>> curves
)
```

## Parameters
- **curves** (`System.Collections.Generic.IList < IList < Curve >>`) - Each array of curves represent a bar in the set.

## Returns
Returns Success(0) if everything is ok, otherwise the failure reason.

## Remarks
This function can fail due to following reasons: One or more of the input curves was null. One or more of the input curves was unbounded. Curves doesn't form a valid curve loop, it forms 0, 2 or more curve loops. A rebar constructed from curves can't be bent according to the bending radius.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor Rebar is constrained.

