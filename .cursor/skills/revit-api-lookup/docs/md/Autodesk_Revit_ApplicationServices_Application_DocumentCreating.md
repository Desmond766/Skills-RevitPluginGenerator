---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.DocumentCreating
source: html/6fbb52ca-889f-3340-30ba-a87c549fcd13.htm
---
# Autodesk.Revit.ApplicationServices.Application.DocumentCreating Event

Subscribe to the DocumentCreating event to be notified when Revit is just about to create a new document.

## Syntax (C#)
```csharp
public event EventHandler<DocumentCreatingEventArgs> DocumentCreating
```

## Remarks
This event is raised when Revit is just about to create a new document. Event is cancellable. To cancel it, call the 'Cancel()' method of event's argument to True.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The document cannot be modified, for it is not created yet at the time of the event. The following API functions are not available for the current document during this event:
 [!:Autodesk::Revit::ApplicationServices::Application::NewProjectDocument()] NewFamilyDocument(String) NewProjectTemplateDocument(String) OpenDocumentFile(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another DocumentCreated event will be raised immediately after document
 creation is finished.

