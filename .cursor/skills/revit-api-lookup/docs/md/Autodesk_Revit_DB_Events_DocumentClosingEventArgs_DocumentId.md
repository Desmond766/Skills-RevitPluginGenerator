---
kind: property
id: P:Autodesk.Revit.DB.Events.DocumentClosingEventArgs.DocumentId
source: html/c1f2fa0f-0071-caef-34d7-b966458fc60b.htm
---
# Autodesk.Revit.DB.Events.DocumentClosingEventArgs.DocumentId Property

Id of the document that is about to be closed.

## Syntax (C#)
```csharp
public int DocumentId { get; }
```

## Remarks
This Id is only used to identify the document for the duration of this event and the DocumentClosed event which follows. It serves as synchronization means for the pair of events.

