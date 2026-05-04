---
kind: property
id: P:Autodesk.Revit.UI.ExternalEvent.IsPending
source: html/355f86f4-a0ca-da4a-e263-1a27069ce174.htm
---
# Autodesk.Revit.UI.ExternalEvent.IsPending Property

Checking whether an event has been raised but not yet executed.

## Syntax (C#)
```csharp
public bool IsPending { get; }
```

## Remarks
When an event is requested to raise it is not executed immediately;
 instead, it waits for the next possible opportunity, which is determined
 by various internal conditions in Revit (policy similar to invoking
 external commands). When the opportunity comes, the event is executed
 by calling the event's handler. In the meantime, the event is 'Pending'.

