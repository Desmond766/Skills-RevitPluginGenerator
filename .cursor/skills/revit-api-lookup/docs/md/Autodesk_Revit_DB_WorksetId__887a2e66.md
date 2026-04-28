---
kind: type
id: T:Autodesk.Revit.DB.WorksetId
source: html/8bece327-c269-8101-b4c2-38632f593fe6.htm
---
# Autodesk.Revit.DB.WorksetId

WorksetId identifies a workset within a single document.

## Syntax (C#)
```csharp
public class WorksetId
```

## Remarks
WorksetId is not guaranteed to be unique. 
It is only valid within one model and its value may change when the model is synchronized with central.
If unique identification of a workset is needed, the workset's GUID should be used instead.

