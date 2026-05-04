---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetConstraintCandidatesForHandle(Autodesk.Revit.DB.Structure.RebarConstrainedHandle,Autodesk.Revit.DB.Reference)
source: html/0639839a-a7a6-064d-5797-9ed609033b53.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetConstraintCandidatesForHandle Method

For shape driven rebar returns all possible RebarConstraints that will constrain RebarConstrainedHandle to the provided reference. For free form rebar will return an empty lists.

## Syntax (C#)
```csharp
public IList<RebarConstraint> GetConstraintCandidatesForHandle(
	RebarConstrainedHandle handle,
	Reference reference
)
```

## Parameters
- **handle** (`Autodesk.Revit.DB.Structure.RebarConstrainedHandle`) - The RebarConstrainedHandle for which constraint candidates are sought.
- **reference** (`Autodesk.Revit.DB.Reference`) - The reference you want to constrain to.

## Returns
A collection of RebarConstraints

## Remarks
Will throw exception if the provided reference cannot be used to constrain the provided rebar handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - reference is not from a valid RebarConstraint target element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RebarConstraintsManager does not manage a valid Rebar element.

