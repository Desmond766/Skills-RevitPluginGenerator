---
kind: property
id: P:Autodesk.Revit.DB.Events.DocumentClosedEventArgs.DocumentId
source: html/b9c0620b-817c-c85e-322e-c56cc942eda2.htm
---
# Autodesk.Revit.DB.Events.DocumentClosedEventArgs.DocumentId Property

Id of the document that has just been closed.

## Syntax (C#)
```csharp
public int DocumentId { get; }
```

## Remarks
This Id is only used to identify the document for the duration of this event and the DocumentClosing event which preceded it. It serves as synchronization means for the pair of events.

