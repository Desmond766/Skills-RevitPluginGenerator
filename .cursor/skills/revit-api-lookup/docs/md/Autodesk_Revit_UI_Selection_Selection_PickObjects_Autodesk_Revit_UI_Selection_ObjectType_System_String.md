---
kind: method
id: M:Autodesk.Revit.UI.Selection.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType,System.String)
zh: 选择、拾取、选取
source: html/ee21d076-057b-f334-70a6-e0dab1d2ac4e.htm
---
# Autodesk.Revit.UI.Selection.Selection.PickObjects Method

**中文**: 选择、拾取、选取

Prompts the user to select multiple objects while showing a custom status prompt string.

## Syntax (C#)
```csharp
public IList<Reference> PickObjects(
	ObjectType objectType,
	string statusPrompt
)
```

## Parameters
- **objectType** (`Autodesk.Revit.UI.Selection.ObjectType`) - Specifies the type of object to be selected.
- **statusPrompt** (`System.String`) - The message shown on the status bar.

## Returns
A collection of references selected by the user. Note: if the user cancels the operation (for example, through ESC), the method will throw an OperationCanceledException instance.

## Remarks
> The user will be shown "Finish" and "Cancel" buttons on the dialog bar to complete the selection operation. 
Uncheck the "Multiple" check-box to select single object and it will return the selected object directly. Revit users will be permitted to manipulate the Revit view (zooming, panning, and rotating the view), 
but will not be permitted to click other items in the Revit user interface. 
Users are not permitted to switch the active view, close the active document or Revit application in the pick session, otherwise an exception will be thrown. The selection will not be automatically added to the active selection buffer. Note: this method must not be called during dynamic update, otherwise ForbiddenForDynamicUpdateException will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the objectType is not a recognized value.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the statusPrompt is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown when the Revit user cancelled this operation. 
Thrown when the Revit user tried to switch the active view, close the active document or Revit application when responding to this mode.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Thrown if this method is called during dynamic update.

