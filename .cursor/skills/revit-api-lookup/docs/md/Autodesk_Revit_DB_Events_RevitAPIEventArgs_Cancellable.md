---
kind: property
id: P:Autodesk.Revit.DB.Events.RevitAPIEventArgs.Cancellable
source: html/a393138a-34b5-1724-aa69-92cef651482b.htm
---
# Autodesk.Revit.DB.Events.RevitAPIEventArgs.Cancellable Property

Indicates whether an event may be cancelled by an event delegate.

## Syntax (C#)
```csharp
public bool Cancellable { get; }
```

## Remarks
If Cancellable returns true, event delegates may cancel the command that
 was announced by the event. To do so, a delegate may call the Cancel() method if it is available.
 Typically, single-events and post-events (e.g. DocumentPrinted) are not cancellable,
 while most pre-events (e.g. DocumentPrinting) are cancellable, except for special
 conditions and situations, such as when the Revit application is being closed
 or if an event is raised during another event.

