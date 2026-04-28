---
kind: method
id: M:Autodesk.Revit.DB.Viewport.IsViewIdValidForViewport(Autodesk.Revit.DB.ElementId)
source: html/9ab7aa51-8dce-bdda-10e5-7d2d3dfd09b2.htm
---
# Autodesk.Revit.DB.Viewport.IsViewIdValidForViewport Method

Verifies that the Viewport can change it's view id to the input %viewId%.

## Syntax (C#)
```csharp
public bool IsViewIdValidForViewport(
	ElementId viewId
)
```

## Parameters
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view which will be checked to see if it can be applied to Viewport.

## Returns
True if the %viewId% is valid for the viewport, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

