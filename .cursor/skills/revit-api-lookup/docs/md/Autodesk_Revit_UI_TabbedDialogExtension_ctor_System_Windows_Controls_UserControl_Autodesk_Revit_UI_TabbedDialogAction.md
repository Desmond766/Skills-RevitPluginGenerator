---
kind: method
id: M:Autodesk.Revit.UI.TabbedDialogExtension.#ctor(System.Windows.Controls.UserControl,Autodesk.Revit.UI.TabbedDialogAction)
source: html/391f389a-7346-343d-8d56-d29fd2814bc1.htm
---
# Autodesk.Revit.UI.TabbedDialogExtension.#ctor Method

Constructs a extension instance with a control and ok action handler.

## Syntax (C#)
```csharp
public TabbedDialogExtension(
	UserControl userControl,
	TabbedDialogAction onOK
)
```

## Parameters
- **userControl** (`System.Windows.Controls.UserControl`) - The control.
- **onOK** (`Autodesk.Revit.UI.TabbedDialogAction`) - The ok action handler.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when userControl or onOK
is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when userControl is already
bound to another tabbed dialog.

