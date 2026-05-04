---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.PostRequestForElementTypePlacement(Autodesk.Revit.DB.ElementType)
source: html/f9bf4ed3-0354-6bc1-6db3-e34fcbace950.htm
---
# Autodesk.Revit.UI.UIDocument.PostRequestForElementTypePlacement Method

Places a request on Revit's command queue for the user to place instances of the specified ElementType. This does not execute immediately,
 but instead when control returns to Revit from the current API context.

## Syntax (C#)
```csharp
public void PostRequestForElementTypePlacement(
	ElementType elementType
)
```

## Parameters
- **elementType** (`Autodesk.Revit.DB.ElementType`) - The ElementType of which instances are to be placed.

## Remarks
This method starts its own transaction. In a single invocation, the user can place multiple instances of the input element type
 until they finish the placement (with Cancel or ESC or a click elsewhere in the UI). This method invokes the UI when control returns
 from the current API context; because of this, the normal Revit UI options will be available to the user, but the API will not be
 notified when the user has completed this action. Because this request is queued to run at the end of the current API context,
 only one such request can be set (between this and the commands set by UIApplication.PostCommand()). This differs from
 PromptForFamilyInstancePlacement() as that method can be run within the current API context, but the user is not permitted
 full access to the user interface options during placement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The user cannot be prompted to place the input type interactively.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This document is not the currently active one.
 -or-
 Starting a new transaction is not permitted. It could be because
 another transaction already started and has not been completed yet,
 or the document is in a state in which it cannot start a new transaction.

