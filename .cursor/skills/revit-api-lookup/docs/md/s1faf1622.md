---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.RemovePreferredConstraintFromHandle(Autodesk.Revit.DB.Structure.RebarConstrainedHandle)
source: html/9920f476-fcf4-0aa7-ec87-9c2975aed905.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.RemovePreferredConstraintFromHandle Method

For ShapeDriven: Clears the user-preferred RebarConstraint from the specified RebarConstrainedHandle. For FreeForm: Removes the RebarConstraint that is associated to the specified RebarConstrainedHandle.

## Syntax (C#)
```csharp
public void RemovePreferredConstraintFromHandle(
	RebarConstrainedHandle handle
)
```

## Parameters
- **handle** (`Autodesk.Revit.DB.Structure.RebarConstrainedHandle`) - The RebarConstrainedHandle for which the user RebarConstraint is to be deleted.

## Remarks
ShapeDriven: After the preferred constraint is removed, the rebar will search for an appropriate
 default constraint for the handle in its current position. In some cases, this will
 cause the handle to snap a small distance to a new target. However, in many situations,
 the handle will simply remain in its current position, and either continue to use the
 same constraint target (while no longer treating that target as preferred), or acquire
 a FixedDistancetoHostFace constraint to the nearest host element surface.
 The handle will not, in general, be restored to the position it originally occupied
 before the preferred constraint was applied. FreeForm: After the Constraint is removed, the handle remains unconstrained, and the shape calculation
 tries to resolve a shape without this information. Depending on the calculation method,
 the bar may not have all the necessary information, so the responsibility to constrain
 this handle is in the hands of the caller of this function.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - handle is no longer valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RebarConstraintsManager does not manage a valid Rebar element.

