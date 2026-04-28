---
kind: method
id: M:Autodesk.Revit.DB.IExportContextBase.OnPolylineSegments(Autodesk.Revit.DB.PolylineSegments)
source: html/c3891505-dd89-50d4-519e-5380af669325.htm
---
# Autodesk.Revit.DB.IExportContextBase.OnPolylineSegments Method

This method is called after unhandled curve was tessellated to polyline segments and sent to the output.
 Note for 2D export: if the export is performed for the view in non-Wireframe display style, then
 this method is called outside of view, instance and link begin/end calls but still between OnElementBegin2D/OnElementEnd2D calls this method is never called for annotation elements, i.e. their geometry should be processed in methods OnCurve and OnPolyline

## Syntax (C#)
```csharp
void OnPolylineSegments(
	PolylineSegments segments
)
```

## Parameters
- **segments** (`Autodesk.Revit.DB.PolylineSegments`) - A structure describing the polyline segments.

