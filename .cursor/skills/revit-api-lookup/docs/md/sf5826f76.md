---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.ApplicationInitialized
source: html/f35ba9fc-0b6b-4284-60eb-91788761127c.htm
---
# Autodesk.Revit.ApplicationServices.Application.ApplicationInitialized Event

Subscribe to this event to get notified after the Revit application has been initialized

## Syntax (C#)
```csharp
public event EventHandler<ApplicationInitializedEventArgs> ApplicationInitialized
```

## Remarks
The event is raised after Revit was launched as fully initialized,
 including initialization of external applications.

