---
kind: type
id: T:Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs
source: html/8b6b969f-45d2-5b90-ca6d-593348ddf8d4.htm
---
# Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs

The base class for the event arguments used by the DialogBoxShowing event.

## Syntax (C#)
```csharp
public class DialogBoxShowingEventArgs : RevitAPIPreEventArgs
```

## Remarks
The actual type of the event arguments will be different depending upon the type of dialog shown.
 When the application receives this object, a dialog is to be displayed in Revit that
 requires user interaction. The OverrideResult function can be used to cause the dialog
 to be dismissed and return a desired result code.

