---
kind: method
id: M:Autodesk.Revit.UI.Selection.Selection.PickElementsByRectangle(System.String)
zh: 框选、框选拾取
source: html/ff8f9e7f-cc92-fe92-6ea4-9f1b581f2bac.htm
---
# Autodesk.Revit.UI.Selection.Selection.PickElementsByRectangle Method

**中文**: 框选、框选拾取

Prompts the user to select multiple elements by drawing a rectangle while showing a custom status prompt string.

## Syntax (C#)
```csharp
public IList<Element> PickElementsByRectangle(
	string statusPrompt
)
```

## Parameters
- **statusPrompt** (`System.String`) - The message shown on the status bar.

## Returns
A collection of elements selected by the user. Note: if the user cancels the operation (for example, through ESC), the method will throw an OperationCanceledException instance.

## Remarks
Revit users will be permitted to manipulate the Revit view (zooming, panning, and rotating the view), 
but will not be permitted to click other items in the Revit user interface. 
Users are not permitted to switch the active view, close the active document or Revit application in the pick session, otherwise an exception will be thrown. The selection will not be automatically added to the active selection buffer. Note: this method must not be called during dynamic update, otherwise ForbiddenForDynamicUpdateException will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the statusPrompt is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown when the Revit user cancelled this operation. 
Thrown when the Revit user tried to switch the active view, close the active document or Revit application when responding to this mode.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Thrown if this method is called during dynamic update.

