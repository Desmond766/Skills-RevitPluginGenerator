---
kind: property
id: P:Autodesk.Revit.DB.Revision.SequenceNumber
source: html/ef7ae04a-ea6d-d3e8-71dc-914739fb737e.htm
---
# Autodesk.Revit.DB.Revision.SequenceNumber Property

The Sequence Number of this Revision.

## Syntax (C#)
```csharp
public int SequenceNumber { get; }
```

## Remarks
Every Revision in the project will be assigned a consecutive sequence number starting with 1.
 This number corresponds to the ordering of the Revisions. If a Revision is deleted, subsequent
 Revisions will update their sequence numbers to maintain a consecutive list.

