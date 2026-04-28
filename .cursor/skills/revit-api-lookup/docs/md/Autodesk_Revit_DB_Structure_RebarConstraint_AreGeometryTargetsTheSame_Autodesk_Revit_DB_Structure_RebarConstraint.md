---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.AreGeometryTargetsTheSame(Autodesk.Revit.DB.Structure.RebarConstraint)
source: html/841c02b2-e2c6-d55c-d4e1-9f1d1d7339a2.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.AreGeometryTargetsTheSame Method

Returns true if the gemetrical targets (ex. face references, other rebar segment references) of "this" constriant are the same as the targets of the "other" constraint.
 Returns false otherwise.
 Only the reference to the target piece of geometry is taken into account(ex. only face references, only other rebar segment references).
 Target Element (elementId) is not taken into account.
 Distance to target is not taken into account.

## Syntax (C#)
```csharp
public bool AreGeometryTargetsTheSame(
	RebarConstraint otherConstraint
)
```

## Parameters
- **otherConstraint** (`Autodesk.Revit.DB.Structure.RebarConstraint`) - Returns the Element object (either Host or Rebar) which provides the constraint.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.

