---
kind: type
id: T:Autodesk.Revit.UI.Events.MessageBoxShowingEventArgs
source: html/aa1b432c-e9b9-b528-aa3b-60514aaea2a3.htm
---
# Autodesk.Revit.UI.Events.MessageBoxShowingEventArgs

The event arguments used by the DialogBoxShowing event when a Windows message box is about to be displayed in Revit.

## Syntax (C#)
```csharp
public class MessageBoxShowingEventArgs : DialogBoxShowingEventArgs
```

## Remarks
When the application receives this object, a simple message box is about to be displayed in Revit that
 requires user interaction. The OverrideResult function can be used to cause the dialog
 to be dismissed and return a desired result code.

