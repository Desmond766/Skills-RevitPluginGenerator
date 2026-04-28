---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.ViewExported
source: html/0a3d3bee-957a-45e0-3779-b1b924a0ce0f.htm
---
# Autodesk.Revit.ApplicationServices.Application.ViewExported Event

Subscribe to the ViewExported event to be notified immediately after Revit has finished exporting a view of the document.

## Syntax (C#)
```csharp
public event EventHandler<ViewExportedEventArgs> ViewExported
```

## Remarks
This event is raised immediately after Revit has finished exporting a view of the document.
 It is raised only during accelerated export jobs, in which views are exported in parallel using a background process.
 Accelerated export only occurs when exporting to DWF formats and not combining views into a single file. It is raised even when view exporting failed. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' field in event's argument to see whether the action was successful or not. This event is not cancellable, for the process of view exporting has already been finished. If the action was not successful, the document may not be modified and new transactions may not be started. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

