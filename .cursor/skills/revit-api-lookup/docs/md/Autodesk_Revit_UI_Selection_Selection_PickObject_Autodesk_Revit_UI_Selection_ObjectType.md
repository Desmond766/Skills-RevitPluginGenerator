---
kind: method
id: M:Autodesk.Revit.UI.Selection.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType)
zh: 选择、拾取、选取
source: html/0315fd62-b533-1817-2f2d-d9ebd4bc8e33.htm
---
# Autodesk.Revit.UI.Selection.Selection.PickObject Method

**中文**: 选择、拾取、选取

Prompts the user to select one object.

## Syntax (C#)
```csharp
public Reference PickObject(
	ObjectType objectType
)
```

## Parameters
- **objectType** (`Autodesk.Revit.UI.Selection.ObjectType`) - Specifies the type of object to be selected.

## Returns
A reference object selected by user. Note: if the user cancels the operation (for example, through ESC), the method will throw an OperationCanceledException instance.

## Remarks
Revit users will be permitted to manipulate the Revit view (zooming, panning, and rotating the view), 
but will not be permitted to click other items in the Revit user interface. 
Users are not permitted to switch the active view, close the active document or Revit application in the pick session, otherwise an exception will be thrown. The selection will not be automatically added to the active selection buffer. Note: this method must not be called during dynamic update, otherwise ForbiddenForDynamicUpdateException will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the objectType is not a recognized value.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown when the Revit user cancels this operation. 
Thrown when the Revit user tried to switch the active view, close the active document or Revit application when responding to this mode.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Thrown if this method is called during dynamic update.

