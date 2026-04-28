---
kind: property
id: P:Autodesk.Revit.DB.Events.RevitEventArgs.Cancel
source: html/a6f19b89-d365-6163-81e5-57849581e27e.htm
---
# Autodesk.Revit.DB.Events.RevitEventArgs.Cancel Property

Indicates whether the event is being cancelled. 
When the event is cancellable, set the property to True to cancel it.

## Syntax (C#)
```csharp
public virtual bool Cancel { get; set; }
```

## Remarks
If an event delegate wishes to cancel the event, it should set the value of this
property to True. Not every event is cancellable. 
Whether or not an event may be cancelled is indicated by the value of 'Cancellable' property.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if an event delegate attempts to cancel a non-cancellable event.

