---
kind: property
id: P:Autodesk.Revit.DB.Workset.IsOpen
zh: 工作集
source: html/62545a89-c7cd-e8b4-2282-ba4a4c909ff0.htm
---
# Autodesk.Revit.DB.Workset.IsOpen Property

**中文**: 工作集

Whether the workset is open (rather than closed).

## Syntax (C#)
```csharp
public bool IsOpen { get; }
```

## Remarks
The intent of closing a workset is to ask Revit to not display or expand any element in the workset, to reduce memory usage.
 Note that open/closed status is independent of editability.

