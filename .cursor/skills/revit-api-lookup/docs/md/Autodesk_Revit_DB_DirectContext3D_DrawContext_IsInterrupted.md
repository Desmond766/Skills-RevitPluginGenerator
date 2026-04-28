---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DrawContext.IsInterrupted
source: html/7e0eb9bd-9a96-a142-5503-1a266cbafb2a.htm
---
# Autodesk.Revit.DB.DirectContext3D.DrawContext.IsInterrupted Method

Checks whether the current rendering pass has been interrupted.

## Syntax (C#)
```csharp
public static bool IsInterrupted()
```

## Returns
True if the current rendering pass has been interrupted before its completion, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This DrawContext is not available because Revit is not currently rendering. In general, this DrawContext must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

