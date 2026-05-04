---
kind: property
id: P:Autodesk.Revit.DB.Events.RevitEventArgs.Cancellable
source: html/57e27fac-4938-589c-154d-5d2e60d89bae.htm
---
# Autodesk.Revit.DB.Events.RevitEventArgs.Cancellable Property

Indicates whether an event may be cancelled by an event delegate.

## Syntax (C#)
```csharp
public virtual bool Cancellable { get; }
```

## Remarks
If 'Cancellable' is true, event delegates may cancel the command that
was announced by the event. To do so, a delegate would set the 'Cancel' property to True.
Typically, post-events (e.g. DocumentPrinted) are not cancellable,
while most pre-events (e.g. DocumentPrinting) are cancellable, except for special
conditions and situations, such as when the Revit application is being closed
or if an event is raised during another event.

