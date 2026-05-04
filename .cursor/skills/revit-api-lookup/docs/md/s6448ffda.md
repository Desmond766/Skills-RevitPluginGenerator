---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IDirectContext3DServer.UseInTransparentPass(Autodesk.Revit.DB.View)
source: html/acaf9ef0-8361-852a-31fa-7f064c21ea7a.htm
---
# Autodesk.Revit.DB.DirectContext3D.IDirectContext3DServer.UseInTransparentPass Method

Indicates whether this server will submit geometry during the rendering pass for transparent geometry.

## Syntax (C#)
```csharp
bool UseInTransparentPass(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view where rendering will occur.

## Returns
True if the server needs to render transparent geometry, false otherwise.

## Remarks
Transparent geometry is rendered in a separate pass following the opaque geometry. If a server
 returns true from UseInTransparentPass(), it can provide geometry for rendering in either pass using
 the RenderScene() method. Otherwise, the server will be called to submit only opaque
 geometry. The server has a way to determine whether it should submit opaque or transparent geometry when
 RenderScene() is called
 (see Autodesk::Revit::DB::DirectContext3D::DrawContext::IsTransparentPass(void)).

