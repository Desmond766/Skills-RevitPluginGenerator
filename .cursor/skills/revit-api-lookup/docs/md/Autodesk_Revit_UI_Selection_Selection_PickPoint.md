---
kind: method
id: M:Autodesk.Revit.UI.Selection.Selection.PickPoint
source: html/e35b0233-64b5-d0c0-713a-292f62942769.htm
---
# Autodesk.Revit.UI.Selection.Selection.PickPoint Method

Prompts the user to pick a point on the active work plane.

## Syntax (C#)
```csharp
public XYZ PickPoint()
```

## Returns
The point picked by user. Note: if the user cancels the operation (for example, through ESC), the method will throw an OperationCanceledException instance.

## Remarks
Revit users will be permitted to manipulate the Revit view (zooming, panning, and rotating the view), 
but will not be permitted to click other items in the Revit user interface. 
Users are not permitted to switch the active view, close the active document or Revit application in the pick session, otherwise an exception will be thrown.
 Note: this method must not be called during dynamic update, otherwise ForbiddenForDynamicUpdateException will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when no work plane set in current view.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown when the Revit user cancelled this operation. 
Thrown when the Revit user tried to close the active document or Revit application when responding to this mode.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Thrown if this method is called during dynamic update.

