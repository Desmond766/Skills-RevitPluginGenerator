---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.ViewsExportingByContext
source: html/1d8c5c16-9458-9846-627a-01d8283c70b5.htm
---
# Autodesk.Revit.ApplicationServices.Application.ViewsExportingByContext Event

Subscribe to the ViewsExportingByContext event to be notified when Revit is just about to export one or more views of the document via an export context by CustomExporter.

## Syntax (C#)
```csharp
public event EventHandler<ViewsExportingByContextEventArgs> ViewsExportingByContext
```

## Remarks
This event is raised when Revit is just about to export views of the document via an export context by CustomExporter. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Event is cancellable. To cancel it, call the 'Cancel()' method in event's argument to True. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another event ViewsExportedByContext will be raised immediately after view exporting by CustomExporter
 is finished.

