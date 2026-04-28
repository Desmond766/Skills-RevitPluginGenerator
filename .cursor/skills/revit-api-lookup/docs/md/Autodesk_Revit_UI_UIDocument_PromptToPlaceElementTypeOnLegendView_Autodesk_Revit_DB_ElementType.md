---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.PromptToPlaceElementTypeOnLegendView(Autodesk.Revit.DB.ElementType)
source: html/f9f2c603-2a3d-f333-42ea-fecfad359c6f.htm
---
# Autodesk.Revit.UI.UIDocument.PromptToPlaceElementTypeOnLegendView Method

Prompts the user to place an element type onto a legend view.

## Syntax (C#)
```csharp
public void PromptToPlaceElementTypeOnLegendView(
	ElementType elementType
)
```

## Parameters
- **elementType** (`Autodesk.Revit.DB.ElementType`) - The ElementType of which instances are to be placed.

## Remarks
This method works only for non-annotation element types.
 For annotations, use PromptForFamilyInstancePlacement(Autodesk::Revit::DB::FamilySymbol) instead.
 This method uses its own transaction, so it's not permitted to be invoked in an active transaction.
 The user is not permitted to change the active legend view or
 during this placement operation (the operation will be cancelled).
 In a single invocation, the user can place multiple instances of the input element type until they finish the
 placement (with Cancel or ESC or a click elsewhere in the UI).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input element type does not belong to a model-level category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This document is not the currently active one.
 -or-
 Starting a new transaction is not permitted. It could be because
 another transaction already started and has not been completed yet,
 or the document is in a state in which it cannot start a new transaction.
 -or-
 Thrown when the active view isn't a legend view.
 -or-
 Can not create this kind of element in legend view.

