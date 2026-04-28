---
kind: method
id: M:Autodesk.Revit.UI.Selection.Selection.PickPoint(Autodesk.Revit.UI.Selection.ObjectSnapTypes,System.String)
source: html/af8ad302-7196-8e2f-f1eb-e5929cda30d9.htm
---
# Autodesk.Revit.UI.Selection.Selection.PickPoint Method

Prompts the user to pick a point on the active work plane using specified snap settings while showing a custom status prompt string.

## Syntax (C#)
```csharp
public XYZ PickPoint(
	ObjectSnapTypes snapSettings,
	string statusPrompt
)
```

## Parameters
- **snapSettings** (`Autodesk.Revit.UI.Selection.ObjectSnapTypes`) - Specifies the object snap types for this pick. Multiple object snap types can be combined with "|"
- **statusPrompt** (`System.String`) - Specifies the message shown on the status bar.

## Returns
The point picked by user. Note: if the user cancels the operation (for example, through ESC), the method will throw an OperationCanceledException instance.

## Remarks
Revit users will be permitted to manipulate the Revit view (zooming, panning, and rotating the view), 
but will not be permitted to click other items in the Revit user interface. 
Users are not permitted to switch the active view, close the active document or Revit application in the pick session, otherwise an exception will be thrown.
 Note: this method must not be called during dynamic update, otherwise ForbiddenForDynamicUpdateException will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the argument statusPrompt is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when no work plane set in current view.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown when the Revit user cancelled this operation. 
Thrown when the Revit user tried to switch the active view, close the active document or Revit application when responding to this mode.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Thrown if this method is called during dynamic update.

