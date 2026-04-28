---
kind: event
id: E:Autodesk.Revit.DB.Document.DocumentClosing
zh: 文档、文件
source: html/8f200255-a515-0c02-656b-b241e0011228.htm
---
# Autodesk.Revit.DB.Document.DocumentClosing Event

**中文**: 文档、文件

Subscribe to the DocumentClosing event to be notified when Revit is just about to close a document.

## Syntax (C#)
```csharp
public event EventHandler<DocumentClosingEventArgs> DocumentClosing
```

## Remarks
This event is raised when Revit is just about to close a document. This event is cancellable, except when it is raised as part of application closing.
 Check the 'Cancellable' property of event's argument to see whether it is cancellable or not.
 When it is cancellable, call the 'Cancel()' method of event's argument to True to cancel it.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The document may not be modified during this event. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another Autodesk::Revit::ApplicationServices::Application::DocumentClosed event will be raised immediately after document is closed.

