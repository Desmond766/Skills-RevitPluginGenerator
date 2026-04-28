---
kind: method
id: M:Autodesk.Revit.DB.IExportContextBase.OnCurve(Autodesk.Revit.DB.CurveNode)
source: html/6306ac1d-c259-5617-f71b-c13e54e5af0d.htm
---
# Autodesk.Revit.DB.IExportContextBase.OnCurve Method

This method is called when a Curve is being output.

## Syntax (C#)
```csharp
RenderNodeAction OnCurve(
	CurveNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.CurveNode`) - An output node that represents a Curve.

## Returns
Return RenderNodeAction.Proceed if you wish to receive tessellated geometry
 (line or polyline segments) for this curve, or otherwise return RenderNodeAction.Skip.
 Note for 2D export: if the export is performed for the view in non-Wireframe display style
 tesselated geometry will be output regardless of the return value.

## Remarks
Note that this method is invoked only if the custom exporter
 was set up to include geometric objects in the output stream.
 See IncludeGeometricObjects for mode details. 
 The curve can be one of the geometric object that derive from the Curve class, e.g. Line, Arc,
 NurbeSpline, etc. To get to the specific properties of the particular class, the curve
 obtained from the input node first needs to be cast accordingly depending on the curve's
 actual type.
 Note for 2D export: if the export is performed for the view in non-Wireframe display style
 this method will be called regardless of whether the object will be eventially output,
 i.e. even if it's occluded by another element.

