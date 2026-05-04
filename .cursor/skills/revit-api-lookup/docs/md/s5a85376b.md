---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.ProgressChanged
source: html/cabf8932-111c-6036-3d74-3d33c18260ed.htm
---
# Autodesk.Revit.ApplicationServices.Application.ProgressChanged Event

Subscribe to the ProgressChanged event to be notified when an operation in Revit has progress bar data available.

## Syntax (C#)
```csharp
public event EventHandler<ProgressChangedEventArgs> ProgressChanged
```

## Remarks
Handlers of this event may use the Cancel () () () method to cancel the operation tracked by the progress bar.
 Users may not change the document in the handler for this event.
 Exception ModificationForbiddenException will be thrown if any document-modifying method is called during this event's handler.

