---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.AllowConstraintTargets(Autodesk.Revit.DB.Structure.RebarConstrainedHandle,System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
source: html/1bfc99e7-7932-5a57-1f11-1d40ed940405.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.AllowConstraintTargets Method

Returns true if references are valid targets for handle, false otherwise.

## Syntax (C#)
```csharp
public bool AllowConstraintTargets(
	RebarConstrainedHandle handle,
	IList<Reference> targetsToConstrain
)
```

## Parameters
- **handle** (`Autodesk.Revit.DB.Structure.RebarConstrainedHandle`) - Represents the constrainable rebar handle.
- **targetsToConstrain** (`System.Collections.Generic.IList < Reference >`) - Represent the refernces to be checked as valid targets for handle.

## Remarks
For a free form rebar valid targets are one or more references to faces of elements that can host rebar. For a shape driven rebar this function will always return false. RebarConstraintsManager.GetConstraintCandidatesForHandle() can be used to obtain possible constraints.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RebarConstraintsManager does not manage a valid Rebar element.

