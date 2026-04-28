---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.ReplaceReferenceTargets(Autodesk.Revit.DB.Structure.RebarConstrainedHandle,System.Collections.Generic.IList{Autodesk.Revit.DB.Reference},System.Boolean,System.Double)
source: html/a94d644d-49ce-9b5e-6068-6a6ffe547c29.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.ReplaceReferenceTargets Method

Replaces the current set of references, the type of constraint and the offset value, with the newly provided ones.
 Will throw exception if this is a constraint for Shape Driven Rebar.

## Syntax (C#)
```csharp
public void ReplaceReferenceTargets(
	RebarConstrainedHandle handle,
	IList<Reference> targetReferences,
	bool isConstraintToCover,
	double offsetValue
)
```

## Parameters
- **handle** (`Autodesk.Revit.DB.Structure.RebarConstrainedHandle`) - The RebarConstrainedHandle that has this constraint.
- **targetReferences** (`System.Collections.Generic.IList < Reference >`) - The references to which the rebar handle will be constrained.
 This collection must contain one or more references to faces of elements that can host rebar.
- **isConstraintToCover** (`System.Boolean`) - If true the RebarConstraintType will be set to ToCover, otherwise RebarConstraintType will be set to FixedDistanceToHostFace.
- **offsetValue** (`System.Double`) - The distance from references to the rebar handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - handle is no longer valid.
 -or-
 targetReferences is empty.
 -or-
 targetReferences do not represent faces from structurals that can host rebar.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Constrained rebar is a shape driven rebar element.

