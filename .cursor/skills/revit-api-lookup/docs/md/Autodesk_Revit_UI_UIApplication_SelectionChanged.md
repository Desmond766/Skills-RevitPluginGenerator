---
kind: event
id: E:Autodesk.Revit.UI.UIApplication.SelectionChanged
source: html/9ac32ac2-974b-235c-ceea-5d436e5b8e59.htm
---
# Autodesk.Revit.UI.UIApplication.SelectionChanged Event

Subscribe to the SelectionChanged event to be notified after the selection was changed.

## Syntax (C#)
```csharp
public event EventHandler<SelectionChangedEventArgs> SelectionChanged
```

## Remarks
This event is raised after the selection was changed in the current document.
 Handlers of this event are forbidden to make modifications to the current document.
 Handlers of this event are forbidden to change the selection to the current document.
 It is not allowed to open a new transaction in the active document when handling this event.

