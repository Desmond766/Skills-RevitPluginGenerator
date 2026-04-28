---
kind: event
id: E:Autodesk.Revit.UI.AddInCommandBinding.CanExecute
source: html/3601b61f-c546-13f3-4928-c0eec4c47b88.htm
---
# Autodesk.Revit.UI.AddInCommandBinding.CanExecute Event

Occurs when the command associated with this AddInCommandBinding initiates a check to determine whether 
the command can be executed on the command target.

## Syntax (C#)
```csharp
public event EventHandler<CanExecuteEventArgs> CanExecute
```

## Remarks
This callback will be called by Revit's user interface any time there is a contextual change. Therefore, the callback
must be fast and is not permitted to be blocking in any way.

