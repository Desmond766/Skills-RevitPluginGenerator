---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarTrimExtendData.CreateEndConstraint(System.Collections.Generic.IList{Autodesk.Revit.DB.Reference},System.Boolean,System.Double)
source: html/30f97bb3-ad2e-6240-6222-afa70754f1f3.htm
---
# Autodesk.Revit.DB.Structure.RebarTrimExtendData.CreateEndConstraint Method

Creates a constraint for the end handle of the rebar. This constraint will be set preferred after the API execution is finished successfully.

## Syntax (C#)
```csharp
public bool CreateEndConstraint(
	IList<Reference> targetReferences,
	bool isConstraintToCover,
	double offsetValue
)
```

## Parameters
- **targetReferences** (`System.Collections.Generic.IList < Reference >`) - The references to which the rebar handle will be constrained.
 Will throw exception if it's empty or if it's anything but Face(s) from a structural that can host rebar.
- **isConstraintToCover** (`System.Boolean`) - If true the RebarConstraintType will be set to ToCover, otherwise RebarConstraintType will be set to FixedDistanceToHostFace.
- **offsetValue** (`System.Double`) - The distance from references to the rebar handle.

## Returns
Returns true if a start constraint can be created with the given references, false otherwise.
 The reference should be faces from structurals that can host rebar.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

