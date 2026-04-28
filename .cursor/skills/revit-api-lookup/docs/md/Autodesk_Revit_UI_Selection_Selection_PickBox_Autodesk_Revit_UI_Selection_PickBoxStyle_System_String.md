---
kind: method
id: M:Autodesk.Revit.UI.Selection.Selection.PickBox(Autodesk.Revit.UI.Selection.PickBoxStyle,System.String)
source: html/3e7cb75e-73ad-d381-1f89-3dab63463c7e.htm
---
# Autodesk.Revit.UI.Selection.Selection.PickBox Method

Invokes a general purpose two-click editor that lets the user to specify a rectangular area on the screen.

## Syntax (C#)
```csharp
public PickedBox PickBox(
	PickBoxStyle style,
	string statusPrompt
)
```

## Parameters
- **style** (`Autodesk.Revit.UI.Selection.PickBoxStyle`) - Specifies the value that controls the style of the pick box.
- **statusPrompt** (`System.String`) - The message shown on the status bar.

## Returns
The picked box that contains two XYZ points.

## Remarks
The method starts an editor and returns when it finishes. Returns a PickedBox that contains two XYZ points.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the style is not a recognized value.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the argument statusPrompt is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown when the Revit user cancelled this operation. 
Thrown when the Revit user tried to switch the active view, close the active document or Revit application when responding to this mode.

