---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.FamilyLoadedIntoDocument
source: html/8c607130-85f3-b6e4-bfb9-a9e2404022c1.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.FamilyLoadedIntoDocument Event

Subscribe to the FamilyLoadedInto event to be notified after Revit loaded a family into a document.

## Syntax (C#)
```csharp
public event EventHandler<FamilyLoadedIntoDocumentEventArgs> FamilyLoadedIntoDocument
```

## Remarks
This event is raised immediately after Revit has finished loading a family into a document.
 It is raised even when family loading failed or was cancelled (during FamilyLoadingIntoDocument event). 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' field in event's argument to see whether the action itself was successful or not. This event is not cancellable, for the process of importing has already been finished. If the action was not successful, the document may not be modified and new transactions may not be started. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

