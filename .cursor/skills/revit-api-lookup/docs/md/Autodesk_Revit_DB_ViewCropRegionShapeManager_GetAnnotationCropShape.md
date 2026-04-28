---
kind: method
id: M:Autodesk.Revit.DB.ViewCropRegionShapeManager.GetAnnotationCropShape
source: html/4e698377-7527-c562-21bc-379c68efda5d.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.GetAnnotationCropShape Method

Gets the annotation crop box assigned to the view.

## Syntax (C#)
```csharp
public CurveLoop GetAnnotationCropShape()
```

## Returns
The annotation crop boundary.

## Remarks
Currently, this method returns only the rectangular annotation crop box.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - View is not allowed to have an annotation crop.

