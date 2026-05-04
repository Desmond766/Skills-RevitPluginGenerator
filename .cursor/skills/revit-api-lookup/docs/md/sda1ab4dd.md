---
kind: type
id: T:Autodesk.Revit.UI.ExternalEvent
source: html/05089477-4612-35b2-81a2-89c4f44370ea.htm
---
# Autodesk.Revit.UI.ExternalEvent

A class that represent an external event.

## Syntax (C#)
```csharp
public class ExternalEvent : IDisposable
```

## Remarks
An instance if this class will be returned to an external event's owner upon the event's creation.
 The event's owner will use this instance to signal that his application needs to be called by Revit.
 Revit will periodically check if any of the events have been signaled (raised), and will execute
 all events that were signaled (raised) by calling the Execute method on the events' respective handlers.

