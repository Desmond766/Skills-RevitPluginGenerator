---
kind: method
id: M:Autodesk.Revit.DB.IExportContext.OnLinkBegin(Autodesk.Revit.DB.LinkNode)
source: html/40d99b4a-e6aa-42d7-18ff-b546d1a5154e.htm
---
# Autodesk.Revit.DB.IExportContext.OnLinkBegin Method

This method marks the beginning of a link instance to be exported.

## Syntax (C#)
```csharp
RenderNodeAction OnLinkBegin(
	LinkNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.LinkNode`)

## Returns
Return RenderNodeAction.Skip if you wish to skip processing this link instance,
 or return RenderNodeAction.Proceed otherwise.

