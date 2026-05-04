---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.SetPreferredConstraintForHandle(Autodesk.Revit.DB.Structure.RebarConstrainedHandle,Autodesk.Revit.DB.Structure.RebarConstraint)
source: html/4ba8adbf-3098-5682-bf09-6a4cc5e0a203.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.SetPreferredConstraintForHandle Method

For ShapeDriven Rebar: Sets the RebarConstraint as preferred constraint target for the specified RebarConstrainedHandle. For FreeForm Rebar: Sets the RebarConstraint as the target for the specified RebarConstraintHandle.

## Syntax (C#)
```csharp
public void SetPreferredConstraintForHandle(
	RebarConstrainedHandle handle,
	RebarConstraint constraint
)
```

## Parameters
- **handle** (`Autodesk.Revit.DB.Structure.RebarConstrainedHandle`) - The RebarConstrainedHandle to which the new RebarConstraint is to be applied.
- **constraint** (`Autodesk.Revit.DB.Structure.RebarConstraint`) - The new RebarConstraint to be applied to the RebarConstrainedHandle.

## Remarks
ShapeDriven: The RebarConstraint should be one of the candidate RebarConstraints returned by
 getConstraintCandidatesForHandle. In general, the caller should assume that the 'set' operation can fail, as some
 of the candidates may be legal targets for the handle, but may cause the rebar
 to flex into an insoluble shape. Once a preferred constraint has been successfully assigned to a handle, the
 user can still drag the handle, and the Rebar can generally be flexed in much
 the same way as it could before (preferred constraints do not have the same
 effect as Revit locked dimensions). However, the rebar's behavior will change
 in subtle ways. A handle with a FixedDistanceToHostFace preferred constraint will allow the
 constraint's offset distance to change as the user moves the handle. However,
 in subsequent model updates, the handle will continue to follow the preferred
 constraint target, even if other legitimate constraint targets are closer to
 the handle. One can think of this behavior as equivalent to unlocking a
 locked dimension, moving one of dimension references, and then re-locking the
 dimension - all in one step. When a handle with a ToCover or ToOtherRebar preferred constraint is dragged by
 the user, it will snap back to its constraint target, unless it is dragged
 beyond tolerance distance. In that case, it will select a new constraint using
 default logic, but will continue to treat the "broken" constraint as preferred,
 and will snap back to the preferred target again, if it is dragged to within
 tolerance distance. If, during a model update, the rebar determines that a preferred constraint
 target no longer exists, or has been modified so that it is no longer a legal
 candidate for the handle, then the rebar will remove the preferred status of
 that target and will assign a new constraint to the handle using the default
 logic. FreeForm: Sets the RebarConstraint to be active for the specified RebarConstrainedHandle.
 The RebarConstrainedHandle needs to be a valid handle for this rebar element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - constraint is no longer valid.
 -or-
 handle is no longer valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RebarConstraintsManager does not manage a valid Rebar element.

