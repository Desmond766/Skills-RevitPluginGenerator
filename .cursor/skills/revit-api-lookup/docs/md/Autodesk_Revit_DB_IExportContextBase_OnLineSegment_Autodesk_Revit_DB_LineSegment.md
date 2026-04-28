---
kind: method
id: M:Autodesk.Revit.DB.IExportContextBase.OnLineSegment(Autodesk.Revit.DB.LineSegment)
source: html/5fe0cee4-825b-9828-2c45-5e4c5019bc37.htm
---
# Autodesk.Revit.DB.IExportContextBase.OnLineSegment Method

This method is called after unhandled curve was tessellated to line segments and sent to the output.
 Note for 2D export: if the export is performed for the view in non-Wireframe display style, then
 this method is called outside of view, instance and link begin/end calls but still between OnElementBegin2D/OnElementEnd2D calls this method is never called for annotation elements, i.e. their geometry should be processed in methods OnCurve and OnPolyline

## Syntax (C#)
```csharp
void OnLineSegment(
	LineSegment segment
)
```

## Parameters
- **segment** (`Autodesk.Revit.DB.LineSegment`) - A structure describing the line segment.

