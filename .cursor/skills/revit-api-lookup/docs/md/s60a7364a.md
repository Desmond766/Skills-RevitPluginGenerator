---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IDirectContext3DServer.RenderScene(Autodesk.Revit.DB.View,Autodesk.Revit.DB.DisplayStyle)
source: html/d8e515cc-5b81-e835-5d60-5b409e0706d8.htm
---
# Autodesk.Revit.DB.DirectContext3D.IDirectContext3DServer.RenderScene Method

Performs rendering of the scene that the server creates.

## Syntax (C#)
```csharp
void RenderScene(
	View dBView,
	DisplayStyle displayStyle
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view where rendering will occur.
- **displayStyle** (`Autodesk.Revit.DB.DisplayStyle`) - The display style of the view in which the submitted geometry will be drawn.

## Remarks
The representation of geometry is in terms of a set of vertex and index buffers. The server can
 use facilities in Autodesk::Revit::DB::DirectContext3D::DrawContext to
 create the buffers and fill them with data that encode primitives such as triangles, lines, and points.
 The server can also adjust the geometry that it submits based on the argument to RenderScene() and in
 response to certain rendering parameters whose values are available through DrawContext (e.g., clip planes). The final step in the process of submitting geometry for rendering is to call DrawContext::FlushBuffer()
 for the appropriate buffers. This interface method may be called in a separate thread from the others.

