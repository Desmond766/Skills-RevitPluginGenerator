---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.FamilyLoadingIntoDocument
source: html/cb807c26-a08a-ec81-e97e-1bdc3ed9699e.htm
---
# Autodesk.Revit.ApplicationServices.Application.FamilyLoadingIntoDocument Event

Subscribe to the FamilyLoadingInto event to be notified when Revit is just about to load a family into a document.

## Syntax (C#)
```csharp
public event EventHandler<FamilyLoadingIntoDocumentEventArgs> FamilyLoadingIntoDocument
```

## Remarks
This event is raised when Revit is just about to load a family into a document. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Event is cancellable. To cancel it, call the 'Cancel()' method in event's argument to True.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The following API functions are not available for the current document during this event:
 All overloads of Autodesk.Revit.DB.Document.Import() Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another FamilyLoadedIntoDocument event will be raised immediately after family loading
 is finished.

