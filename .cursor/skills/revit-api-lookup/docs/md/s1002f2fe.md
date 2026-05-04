---
kind: property
id: P:Autodesk.Revit.DB.DocumentPreviewSettings.PreviewViewId
source: html/5ce1e6a9-1ba9-fb09-1185-31956ce421bd.htm
---
# Autodesk.Revit.DB.DocumentPreviewSettings.PreviewViewId Property

The view id that will be used to generate the preview.

## Syntax (C#)
```csharp
public ElementId PreviewViewId { get; set; }
```

## Remarks
This view will always be saved as the preview view for the document unless it is overridden
 by the value used in SaveOptions or SaveAsOptions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The view id is not valid to use as a preview view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

