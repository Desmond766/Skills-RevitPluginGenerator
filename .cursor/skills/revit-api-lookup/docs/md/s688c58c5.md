---
kind: method
id: M:Autodesk.Revit.DB.IExportContext.OnInstanceBegin(Autodesk.Revit.DB.InstanceNode)
source: html/2db35bdb-8d14-a015-9bfb-9283f503edab.htm
---
# Autodesk.Revit.DB.IExportContext.OnInstanceBegin Method

This method marks the start of processing of an instance node (e.g. a family instance).

## Syntax (C#)
```csharp
RenderNodeAction OnInstanceBegin(
	InstanceNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.InstanceNode`)

## Returns
Return RenderNodeAction.Skip if you wish to skip processing this family instance,
 or return RenderNodeAction.Proceed otherwise.

