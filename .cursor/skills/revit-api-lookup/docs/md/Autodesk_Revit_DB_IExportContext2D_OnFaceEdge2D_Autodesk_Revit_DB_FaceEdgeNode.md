---
kind: method
id: M:Autodesk.Revit.DB.IExportContext2D.OnFaceEdge2D(Autodesk.Revit.DB.FaceEdgeNode)
source: html/c45260d6-c34c-3198-3ccf-d256348832bd.htm
---
# Autodesk.Revit.DB.IExportContext2D.OnFaceEdge2D Method

This method is called when a Face edge is being output.

## Syntax (C#)
```csharp
RenderNodeAction OnFaceEdge2D(
	FaceEdgeNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.FaceEdgeNode`) - An output node that represents a Face edge.

## Returns
Return RenderNodeAction.Proceed if you wish to receive tessellated geometry
 (line or polyline segments) for this face edge, or otherwise return RenderNodeAction.Skip.
 Note: if the export is performed for the view in non-Wireframe display style
 tesselated geometry will be output regardless of the return value.

## Remarks
Note that this method is invoked only if the custom exporter
 was set up to include geometric objects in the output stream.
 See IncludeGeometricObjects for mode details. Note: if the export is performed for the view in non-Wireframe display style
 this method will be called regardless of whether the object will be eventially output,
 i.e. even if it's occluded by another element.

