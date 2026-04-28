---
kind: method
id: M:Autodesk.Revit.DB.DocumentPreviewSettings.IsViewIdValidForPreview(Autodesk.Revit.DB.ElementId)
source: html/a7fac975-16eb-e41c-c6fb-daca3a60fc43.htm
---
# Autodesk.Revit.DB.DocumentPreviewSettings.IsViewIdValidForPreview Method

Identifies if the view id is valid as a preview view id.

## Syntax (C#)
```csharp
public bool IsViewIdValidForPreview(
	ElementId viewId
)
```

## Parameters
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id.

## Returns
True if the view id is valid for preview, false otherwise.

## Remarks
Only graphical views (3d or 2d) are valid for use as a preview view. Other
 views (such as view templates) will not pass this method. InvalidElementId
 is accepted by this method as this id means that no special view is set for the
 preview.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

