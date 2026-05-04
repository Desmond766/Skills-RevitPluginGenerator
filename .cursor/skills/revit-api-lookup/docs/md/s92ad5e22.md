---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.ViewsExportedByContext
source: html/8488474a-5499-567b-4505-89ba6c401c63.htm
---
# Autodesk.Revit.ApplicationServices.Application.ViewsExportedByContext Event

Subscribe to the ViewsExportedByContext event to be notified immediately after Revit has finished exporting one or more views of the document via an export context by CustomExporter.

## Syntax (C#)
```csharp
public event EventHandler<ViewsExportedByContextEventArgs> ViewsExportedByContext
```

## Remarks
This event is raised immediately after Revit has finished exporting views of the document via an export context by CustomExporter. It is raised even when view exporting via export context by CustomExporter failed. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' field in event's argument to see whether the action was successful or not. This event is not cancellable, for the process of view exporting by CustomExporter has already been finished. If the action was not successful, the document may not be modified and new transactions may not be started. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

