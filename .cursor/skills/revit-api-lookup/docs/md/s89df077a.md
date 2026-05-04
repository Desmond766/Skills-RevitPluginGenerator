---
kind: method
id: M:Autodesk.Revit.DB.IModelExportContext.OnPoint(Autodesk.Revit.DB.PointNode)
source: html/6d0a592f-9961-e0ff-70a3-b67bb815e0d4.htm
---
# Autodesk.Revit.DB.IModelExportContext.OnPoint Method

This method is called when a Point is being output.

## Syntax (C#)
```csharp
RenderNodeAction OnPoint(
	PointNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.PointNode`) - An output node that represents a Point.

## Returns
Return RenderNodeAction.Proceed if you wish to receive low-level geometry
 (line segments) for this point, or otherwise return RenderNodeAction.Skip.

## Remarks
Note that this method is invoked only if the custom exporter
 was set up to include geometric objects in the output stream.
 See IncludeGeometricObjects for mode details.

