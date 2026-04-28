---
kind: property
id: P:Autodesk.Revit.DB.SaveOptions.PreviewViewId
source: html/0bd7569d-9d7e-5ac3-c783-b6db08a30c2d.htm
---
# Autodesk.Revit.DB.SaveOptions.PreviewViewId Property

The view id that will be used to generate the preview; this id is not saved to the document's permanent settings.

## Syntax (C#)
```csharp
public ElementId PreviewViewId { get; set; }
```

## Remarks
If this id is set, the indicated view will be used to generate the preview even if
 DocumentPreviewSettings.PreviewViewId is also set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

