---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.DocumentSaved
source: html/bb944bb2-2141-4116-339f-4d13b6f6a6a5.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.DocumentSaved Event

Subscribe to the DocumentSaved event to be notified immediately after Revit has finished saving a document.

## Syntax (C#)
```csharp
public event EventHandler<DocumentSavedEventArgs> DocumentSaved
```

## Remarks
This event is raised immediately after Revit has finished saving a document.
 Note that the first save of a newly created document will raise DocumentSavedAs 
 rather than the DocumentSaved event.
 It is raised even when document saving failed or was cancelled (during DocumentSaving event). 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' property in event's argument to see whether the action itself was successful or not. This event is not cancellable, for the process of saving document has already been finished. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

