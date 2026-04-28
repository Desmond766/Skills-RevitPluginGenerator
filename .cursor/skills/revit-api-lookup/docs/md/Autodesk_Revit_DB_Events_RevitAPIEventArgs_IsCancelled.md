---
kind: method
id: M:Autodesk.Revit.DB.Events.RevitAPIEventArgs.IsCancelled
source: html/5627aeaa-9d9c-dcbe-b34f-db40f1c025be.htm
---
# Autodesk.Revit.DB.Events.RevitAPIEventArgs.IsCancelled Method

Indicates whether the event is being cancelled.

## Syntax (C#)
```csharp
public bool IsCancelled()
```

## Remarks
If the event is cancellable and an event delegate wishes to cancel the event, it may call the Cancel() method if it is available for a particular event's arguments.

