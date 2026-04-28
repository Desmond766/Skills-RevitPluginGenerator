---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DrawContext.SetWorldTransform(Autodesk.Revit.DB.Transform)
source: html/4917c16f-5f9e-6172-7b5d-32d6174d6adf.htm
---
# Autodesk.Revit.DB.DirectContext3D.DrawContext.SetWorldTransform Method

Sets the world transformation that will be applied to geometry during rendering.

## Syntax (C#)
```csharp
public static void SetWorldTransform(
	Transform trf
)
```

## Parameters
- **trf** (`Autodesk.Revit.DB.Transform`) - The transformation matrix.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This DrawContext is not available because Revit is not currently rendering. In general, this DrawContext must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

