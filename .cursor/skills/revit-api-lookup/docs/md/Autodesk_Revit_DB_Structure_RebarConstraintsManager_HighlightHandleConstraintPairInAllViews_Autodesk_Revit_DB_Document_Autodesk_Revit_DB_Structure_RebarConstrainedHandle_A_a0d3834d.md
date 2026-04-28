---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.HighlightHandleConstraintPairInAllViews(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.RebarConstrainedHandle,Autodesk.Revit.DB.Structure.RebarConstraint)
source: html/4d33c054-d51a-f0a5-15a0-41625ca5e2a4.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.HighlightHandleConstraintPairInAllViews Method

Highlights the specified RebarConstrainedHandle and RebarConstraint in all views.

## Syntax (C#)
```csharp
public void HighlightHandleConstraintPairInAllViews(
	Document aDoc,
	RebarConstrainedHandle handle,
	RebarConstraint constraint
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`)
- **handle** (`Autodesk.Revit.DB.Structure.RebarConstrainedHandle`) - The RebarConstrainedHandle to be highlighted in all views.
- **constraint** (`Autodesk.Revit.DB.Structure.RebarConstraint`) - The RebarConstraint to be highlighted in all views.

## Remarks
This method is provided as a way to help end users visualize more easily the effect
 that selecting new RebarConstraints for the Rebar element's RebarConstrainedHandle
 will have on the Rebar. It is purely for graphical output, and does not assume any
 relationship between the RebarConstrainedHandle and the RebarConstraint. The caller
 is responsible for updating (or clearing) the highlighting in response to changes
 in the Rebar's constraints.
 Repeated calls to this method are not cumulative; highlighting from previous calls
 will be cleared before new highlighting is applied.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - constraint is no longer valid.
 -or-
 handle is no longer valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RebarConstraintsManager does not manage a valid Rebar element.

