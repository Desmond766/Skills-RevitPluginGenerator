---
kind: method
id: M:Autodesk.Revit.DB.View.GetCropRegionShapeManagerForReferenceCallout(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/248f20e0-9735-5733-2c8a-6b871bb17d3b.htm
---
# Autodesk.Revit.DB.View.GetCropRegionShapeManagerForReferenceCallout Method

**中文**: 视图

Returns an object for managing view crop region shape for reference callout.

## Syntax (C#)
```csharp
public static ViewCropRegionShapeManager GetCropRegionShapeManagerForReferenceCallout(
	Document doc,
	ElementId callout
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - Document to which the callout belongs.
- **callout** (`Autodesk.Revit.DB.ElementId`) - Element id of reference callout.

## Returns
The crop region shape manager.

## Remarks
Reference callout is a view-specific element referencing another view.
 It can have its own crop region shape which doesn't affect the referenced view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

