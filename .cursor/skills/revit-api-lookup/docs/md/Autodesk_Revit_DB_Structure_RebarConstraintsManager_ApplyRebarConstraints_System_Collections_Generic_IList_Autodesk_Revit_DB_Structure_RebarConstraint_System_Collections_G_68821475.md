---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.ApplyRebarConstraints(System.Collections.Generic.IList{Autodesk.Revit.DB.Structure.RebarConstraint},System.Collections.Generic.IList{Autodesk.Revit.DB.Reference},System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
source: html/ea70f469-13c9-8fea-a2f1-34796dc2c416.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.ApplyRebarConstraints Method

Returns true if constraints were applied to rebar with success.

## Syntax (C#)
```csharp
public bool ApplyRebarConstraints(
	IList<RebarConstraint> constraintsToApply,
	IList<Reference> oldTargets,
	IList<Reference> newTargets
)
```

## Parameters
- **constraintsToApply** (`System.Collections.Generic.IList < RebarConstraint >`) - Represent the new constraints to be applied to rebar.
- **oldTargets** (`System.Collections.Generic.IList < Reference >`) - Represent the old target references.
- **newTargets** (`System.Collections.Generic.IList < Reference >`) - Represent the new target references.

## Returns
Returns true if the constraints were applied succesfully, false otherwise

## Remarks
ShapeDriven : The input constraints belong to other rebar in a (different) similar host. Only constraints of type ToHostFace or ToCover are considered.
 The method modifies the constraints' target references with their correspondants in current host(s).
 The modified constraints are set in current rebar.
 The method will fail : if there exists at least one ToOtherRebar constraint; if corresponding target references in current host(s) are not supplied or found. FreeForm : The constraints will not be applied and the method will return false. The two arrays go hand in hand : they must have the same size; the correspondant of oldReference at index x is found in the other array at the same index x.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RebarConstraintsManager does not manage a valid Rebar element.

