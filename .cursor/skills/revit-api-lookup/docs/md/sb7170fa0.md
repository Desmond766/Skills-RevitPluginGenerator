---
kind: property
id: P:Autodesk.Revit.DB.SaveAsOptions.PreviewViewId
source: html/d75283fb-868c-bda3-277b-b0c1d3a65893.htm
---
# Autodesk.Revit.DB.SaveAsOptions.PreviewViewId Property

The view id that will be used to generate the preview; this id is not saved to the document's permanent settings.

## Syntax (C#)
```csharp
public ElementId PreviewViewId { get; set; }
```

## Remarks
If this id is set to a view id, the indicated view will be used to generate the preview even if
 DocumentPreviewSettings.PreviewViewId is also set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

