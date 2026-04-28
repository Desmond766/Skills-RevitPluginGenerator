---
kind: method
id: M:Autodesk.Revit.UI.Selection.Selection.PickElementsByRectangle
zh: 框选、框选拾取
source: html/2be6b3b7-2cec-1d8a-76fb-afcd618fcae6.htm
---
# Autodesk.Revit.UI.Selection.Selection.PickElementsByRectangle Method

**中文**: 框选、框选拾取

Prompts the user to select multiple elements by drawing a rectangle.

## Syntax (C#)
```csharp
public IList<Element> PickElementsByRectangle()
```

## Returns
A collection of elements selected by the user. Note: if the user cancels the operation (for example, through ESC), the method will throw an OperationCanceledException instance.

## Remarks
Revit users will be permitted to manipulate the Revit view (zooming, panning, and rotating the view), 
but will not be permitted to click other items in the Revit user interface. 
Users are not permitted to switch the active view, close the active document or Revit application in the pick session, otherwise an exception will be thrown. The selection will not be automatically added to the active selection buffer. Note: this method must not be called during dynamic update, otherwise ForbiddenForDynamicUpdateException will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown when the Revit user cancelled this operation. 
Thrown when the Revit user tried to switch the active view, close the active document or Revit application when responding to this mode.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Thrown if this method is called during dynamic update.

