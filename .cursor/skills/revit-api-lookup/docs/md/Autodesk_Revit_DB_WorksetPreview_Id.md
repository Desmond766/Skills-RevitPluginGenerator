---
kind: property
id: P:Autodesk.Revit.DB.WorksetPreview.Id
source: html/a0bd368d-c9ca-017f-63b1-0a811ed4598f.htm
---
# Autodesk.Revit.DB.WorksetPreview.Id Property

Id of the workset.

## Syntax (C#)
```csharp
public WorksetId Id { get; }
```

## Remarks
Id of the workset may be changed while synchronizing with central. Please use UniqueId to reliably identify worksets despite changes which occur due to synchronization with central.

