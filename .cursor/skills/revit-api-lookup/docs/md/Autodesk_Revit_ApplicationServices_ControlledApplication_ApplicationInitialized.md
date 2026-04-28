---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.ApplicationInitialized
source: html/1d917597-712c-cec3-db2a-8301c62a8ee3.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.ApplicationInitialized Event

Subscribe to this event to get notified after the Revit application has been initialized

## Syntax (C#)
```csharp
public event EventHandler<ApplicationInitializedEventArgs> ApplicationInitialized
```

## Remarks
The event is raised after Revit was launched as fully initialized,
 including initialization of external applications.

