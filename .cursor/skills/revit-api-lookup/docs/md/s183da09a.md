---
kind: event
id: E:Autodesk.Revit.UI.UIControlledApplication.SelectionChanged
source: html/81ada6e8-47f1-4ff6-fcb8-907e0a389c7c.htm
---
# Autodesk.Revit.UI.UIControlledApplication.SelectionChanged Event

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

