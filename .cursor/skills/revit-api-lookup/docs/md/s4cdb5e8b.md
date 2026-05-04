---
kind: method
id: M:Autodesk.Revit.UI.ExternalEvent.Raise
source: html/13bf4411-c400-dcd2-458c-7f09357d9ecb.htm
---
# Autodesk.Revit.UI.ExternalEvent.Raise Method

Instructing Revit to raise (signal) the external event.

## Syntax (C#)
```csharp
public ExternalEventRequest Raise()
```

## Returns
The result of event raising request. If the request is 'Accepted',
 the event would be added to the event queue and its handler will
 be executed in the next event-processing cycle.

## Remarks
Revit will wait until it is ready to process the event and then
 it will execute its event handler by calling the Execute method.
 Revit processes external events only when no other commands or
 edit modes are currently active in Revit, which is the same policy
 like the one that applies to evoking external commands.

