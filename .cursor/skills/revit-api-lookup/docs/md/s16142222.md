---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetConstraintCandidatesForHandle(Autodesk.Revit.DB.Structure.RebarConstrainedHandle)
source: html/5931ac8a-f3bd-ef34-970e-4327c3ce640e.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetConstraintCandidatesForHandle Method

For shape driven rebar returns all possible RebarConstraints that could be used for a specified RebarConstrainedHandle. For free form rebar will return an empty list.

## Syntax (C#)
```csharp
public IList<RebarConstraint> GetConstraintCandidatesForHandle(
	RebarConstrainedHandle handle
)
```

## Parameters
- **handle** (`Autodesk.Revit.DB.Structure.RebarConstrainedHandle`) - The RebarConstrainedHandle for which constraint candidates are sought.

## Returns
A collection of RebarConstraints

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RebarConstraintsManager does not manage a valid Rebar element.

