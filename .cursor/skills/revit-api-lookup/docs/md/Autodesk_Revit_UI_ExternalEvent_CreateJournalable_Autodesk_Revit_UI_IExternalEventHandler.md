---
kind: method
id: M:Autodesk.Revit.UI.ExternalEvent.CreateJournalable(Autodesk.Revit.UI.IExternalEventHandler)
source: html/4b93e520-804b-9046-5c79-845abf16783a.htm
---
# Autodesk.Revit.UI.ExternalEvent.CreateJournalable Method

Creates an instance of external event which will have the ability to record its executions in the journal.

## Syntax (C#)
```csharp
public static ExternalEvent CreateJournalable(
	IExternalEventHandler handler
)
```

## Parameters
- **handler** (`Autodesk.Revit.UI.IExternalEventHandler`) - An instance of IExternalEventHandler which will execute the event.

## Returns
An instance of ExternalEvent class, which will be used to invoke the event

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

