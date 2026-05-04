---
kind: method
id: M:Autodesk.Revit.UI.Selection.Selection.PickBox(Autodesk.Revit.UI.Selection.PickBoxStyle)
source: html/0df6000f-3639-5e7b-1c43-9ec40938b9c4.htm
---
# Autodesk.Revit.UI.Selection.Selection.PickBox Method

Invokes a general purpose two-click editor that lets the user to specify a rectangular area on the screen.

## Syntax (C#)
```csharp
public PickedBox PickBox(
	PickBoxStyle style
)
```

## Parameters
- **style** (`Autodesk.Revit.UI.Selection.PickBoxStyle`) - Specifies the value that controls the style of the pick box.

## Returns
The picked box that contains two XYZ points.

## Remarks
The method starts an editor and returns when it finishes. Returns a PickedBox that contains two XYZ points.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the style is not a recognized value.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown when the Revit user cancelled this operation. 
Thrown when the Revit user tried to switch the active view, close the active document or Revit application when responding to this mode.

