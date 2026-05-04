---
kind: method
id: M:Autodesk.Revit.UI.Selection.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType,Autodesk.Revit.UI.Selection.ISelectionFilter,System.String)
zh: 选择、拾取、选取
source: html/e55e4998-ef65-6021-f448-6046be134533.htm
---
# Autodesk.Revit.UI.Selection.Selection.PickObject Method

**中文**: 选择、拾取、选取

Prompts the user to select one object which passes a custom filter while showing a custom status prompt string.

## Syntax (C#)
```csharp
public Reference PickObject(
	ObjectType objectType,
	ISelectionFilter selectionFilter,
	string statusPrompt
)
```

## Parameters
- **objectType** (`Autodesk.Revit.UI.Selection.ObjectType`) - Specifies the type of object to be selected.
- **selectionFilter** (`Autodesk.Revit.UI.Selection.ISelectionFilter`) - The selection filter.
- **statusPrompt** (`System.String`) - The message shown on the status bar.

## Returns
A reference object selected by user. Note: if the user cancels the operation (for example, through ESC), the method will throw an OperationCanceledException instance.

## Remarks
Revit users will be permitted to manipulate the Revit view (zooming, panning, and rotating the view), 
but will not be permitted to click other items in the Revit user interface. 
Users are not permitted to switch the active view, close the active document or Revit application in the pick session, otherwise an exception will be thrown. The selection will not be automatically added to the active selection buffer. Note: this method must not be called during dynamic update, otherwise ForbiddenForDynamicUpdateException will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the objectType is not a recognized value.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the selectionFilter is Nothing nullptr a null reference ( Nothing in Visual Basic) or statusPrompt is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown when the Revit user cancelled this operation. 
Thrown when the Revit user tried to switch the active view, close the active document or Revit application when responding to this mode.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Thrown if this method is called during dynamic update.

