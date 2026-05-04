---
kind: method
id: M:Autodesk.Revit.DB.IExportContext.OnViewBegin(Autodesk.Revit.DB.ViewNode)
source: html/959602b7-5257-d2c1-2c00-0b7649f145f5.htm
---
# Autodesk.Revit.DB.IExportContext.OnViewBegin Method

This method marks the beginning of a 3D view to be exported.

## Syntax (C#)
```csharp
RenderNodeAction OnViewBegin(
	ViewNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.ViewNode`) - Geometry node associated with the view.

## Returns
Return RenderNodeAction.Skip if you wish to skip exporting this view,
 or return RenderNodeAction.Proceed otherwise.

