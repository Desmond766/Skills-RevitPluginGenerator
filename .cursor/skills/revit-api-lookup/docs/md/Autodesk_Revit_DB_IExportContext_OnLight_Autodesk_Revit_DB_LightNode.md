---
kind: method
id: M:Autodesk.Revit.DB.IExportContext.OnLight(Autodesk.Revit.DB.LightNode)
source: html/d56129ca-950b-34fc-89ac-f0fb2e7fe9f2.htm
---
# Autodesk.Revit.DB.IExportContext.OnLight Method

This method marks the beginning of export of a light which is enabled for rendering.

## Syntax (C#)
```csharp
void OnLight(
	LightNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.LightNode`) - A node describing the light object.

## Remarks
This method is only called for photo-rendering export (a custom exporter that implements IPhotoRenderContext ).

