---
kind: method
id: M:Autodesk.Revit.DB.IExportContextBase.OnPolyline(Autodesk.Revit.DB.PolylineNode)
source: html/12a8d0af-f3e2-e5f3-aa19-797adebaff2b.htm
---
# Autodesk.Revit.DB.IExportContextBase.OnPolyline Method

This method is called when a Polyline is being output.

## Syntax (C#)
```csharp
RenderNodeAction OnPolyline(
	PolylineNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.PolylineNode`) - An output node that represents a Polyline.

## Returns
Return RenderNodeAction.Proceed if you wish to receive tessellated geometry
 (polyline segments) for this polyline, or otherwise return RenderNodeAction.Skip.
 Note for 2D export: if the export is performed for the view in non-Wireframe display style
 tesselated geometry will be output regardless of the return value.

## Remarks
Note that this method is invoked only if the custom exporter
 was set up to include geometric objects in the output stream.
 See IncludeGeometricObjects for mode details.
 Note for 2D export: if the export is performed for the view in non-Wireframe display style
 this method will be called regardless of whether the object will be eventially output,
 i.e. even if it's occluded by another element.

