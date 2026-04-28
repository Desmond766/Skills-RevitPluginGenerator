---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DrawContext.IsTransparentPass
source: html/e7a6cb5b-d23b-9269-591d-6ca37790176d.htm
---
# Autodesk.Revit.DB.DirectContext3D.DrawContext.IsTransparentPass Method

Determines whether the current rendering pass is for transparent objects.

## Syntax (C#)
```csharp
public static bool IsTransparentPass()
```

## Returns
True when the server should be submitting transparent objects for rendering, false otherwise.

## Remarks
Opaque and transparent geometry should be submitted for rendering separately.
 See UseInTransparentPass(View) .

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This DrawContext is not available because Revit is not currently rendering. In general, this DrawContext must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

