---
kind: method
id: M:Autodesk.Revit.DB.IExportContext2D.OnFaceSilhouette2D(Autodesk.Revit.DB.FaceSilhouetteNode)
source: html/ecad235e-baea-5217-4955-bf735034d57b.htm
---
# Autodesk.Revit.DB.IExportContext2D.OnFaceSilhouette2D Method

This method is called when a Face silhouette is being output.

## Syntax (C#)
```csharp
RenderNodeAction OnFaceSilhouette2D(
	FaceSilhouetteNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.FaceSilhouetteNode`) - An output node that represents a Face silhouette.

## Returns
Return RenderNodeAction.Proceed if you wish to receive tessellated geometry
 (line or polyline segments) for this face silhouette, or otherwise return RenderNodeAction.Skip.
 Note: if the export is performed for the view in non-Wireframe display style
 tesselated geometry will be output regardless of the return value.

## Remarks
Note that this method is invoked only if the custom exporter
 was set up to include geometric objects in the output stream.
 See IncludeGeometricObjects for mode details. Note: if the export is performed for the view in non-Wireframe display style
 this method will be called regardless of whether the object will be eventially output,
 i.e. even if it's occluded by another element.

