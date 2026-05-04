---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetConstraintCandidatesForHandle(Autodesk.Revit.DB.Structure.RebarConstrainedHandle,Autodesk.Revit.DB.ElementId)
source: html/7fb6f4f8-a01f-b6c5-e553-08197ef55db6.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetConstraintCandidatesForHandle Method

For shape driven rebar returns all possible RebarConstraints belonging to references from the provided element that could be used for a specified RebarConstrainedHandle. For free form rebar will return an empty list.

## Syntax (C#)
```csharp
public IList<RebarConstraint> GetConstraintCandidatesForHandle(
	RebarConstrainedHandle handle,
	ElementId elementId
)
```

## Parameters
- **handle** (`Autodesk.Revit.DB.Structure.RebarConstrainedHandle`) - The RebarConstrainedHandle for which constraint candidates are sought.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The elementId ( host or rebar ) of the element in which the candidates are searched for.

## Returns
A collection of RebarConstraints

## Remarks
Will throw exception if the provided elementId is not a valid constraint target.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - elementId is not a valid RebarConstraint target element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RebarConstraintsManager does not manage a valid Rebar element.

