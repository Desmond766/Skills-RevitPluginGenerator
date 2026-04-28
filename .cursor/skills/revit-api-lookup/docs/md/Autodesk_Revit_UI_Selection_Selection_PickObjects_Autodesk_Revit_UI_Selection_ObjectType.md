---
kind: method
id: M:Autodesk.Revit.UI.Selection.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType)
zh: 选择、拾取、选取
source: html/577ac5d0-8a6d-8e73-9d0d-259ed0ac6024.htm
---
# Autodesk.Revit.UI.Selection.Selection.PickObjects Method

**中文**: 选择、拾取、选取

Prompts the user to select multiple objects.

## Syntax (C#)
```csharp
public IList<Reference> PickObjects(
	ObjectType objectType
)
```

## Parameters
- **objectType** (`Autodesk.Revit.UI.Selection.ObjectType`) - Specifies the type of object to be selected.

## Returns
A collection of references selected by the user. Note: if the user cancels the operation (for example, through ESC), the method will throw an OperationCanceledException instance.

## Remarks
The user will be shown "Finish" and "Cancel" buttons on the dialog bar to complete the selection operation. 
Uncheck the "Multiple" check-box to select single object and it will return the selected object directly. Revit users will be permitted to manipulate the Revit view (zooming, panning, and rotating the view), 
but will not be permitted to click other items in the Revit user interface. 
Users are not permitted to switch the active view, close the active document or Revit application in the pick session, otherwise an exception will be thrown. The selection will not be automatically added to the active selection buffer. Note: this method must not be called during dynamic update, otherwise ForbiddenForDynamicUpdateException will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the objectType is not a recognized value.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown when the Revit user cancelled this operation. 
Thrown when the Revit user tried to switch the active view, close the active document or Revit application when responding to this mode.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Thrown if this method is called during dynamic update.

