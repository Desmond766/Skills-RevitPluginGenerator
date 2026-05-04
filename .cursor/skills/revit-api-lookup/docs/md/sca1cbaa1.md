---
kind: method
id: M:Autodesk.Revit.DB.Events.RevitAPIPreEventArgs.Cancel
source: html/88fa78de-0fff-a85f-0de3-b631673e9e51.htm
---
# Autodesk.Revit.DB.Events.RevitAPIPreEventArgs.Cancel Method

When the event is cancellable, may call the Cancel() method to cancel it.

## Syntax (C#)
```csharp
public void Cancel()
```

## Remarks
Not every event is cancellable.
 Whether or not an event may be cancelled is indicated by IsCancellable() method.

