---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DrawContext.IsAvailable
source: html/7282d58a-ba94-79d1-dff1-7782ecdacf84.htm
---
# Autodesk.Revit.DB.DirectContext3D.DrawContext.IsAvailable Method

Checks whether the facilities of this class are available for use in the current scope.

## Syntax (C#)
```csharp
public static bool IsAvailable()
```

## Returns
True if the DrawContext is available for rendering, false otherwise.

## Remarks
This class can perform drawing operations and access the state of parameters related to drawing only
 in lock-step with rendering inside of Revit. As a consequence, the facilities of this class are not available for
 use outside of the scope determined by the callback RenderScene(View, DisplayStyle) .
 Certain methods of other DirectContext3D objects, e.g., VertexBuffer::Map() are similarly restricted by the same scope.

