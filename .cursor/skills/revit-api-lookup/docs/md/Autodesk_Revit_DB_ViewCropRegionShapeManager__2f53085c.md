---
kind: type
id: T:Autodesk.Revit.DB.ViewCropRegionShapeManager
source: html/2610cb66-5dae-9fc8-4e83-7dfe88085abb.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager

A class that provides access to settings related to the crop assigned to a view or a reference callout.

## Syntax (C#)
```csharp
public class ViewCropRegionShapeManager : IDisposable
```

## Remarks
This class manages all the settings that make up the model and annotation crop geometry for a given view or reference callout.
 You can obtain the settings for a view from GetCropRegionShapeManager () () () .
 Obtain the settings for a reference callout from GetCropRegionShapeManagerForReferenceCallout(Document, ElementId) .
The model crop region crops model elements, detail elements (such as insulation and detail lines), section boxes,
 and scope boxes at the model crop boundary.
 Visible crop boundaries of other related views are also cropped at the model crop boundary.
 The model crop region can be set as a polygonal boundary, a rectangular boundary,
 or rectangular boundary with one or more splits applied either horizontally or vertically.
 If a split is applied to the rectangular crop each resulting rectangular region is identified by a region index and occupies
 a percentage of the original crop rectangle. The regions may possibly be moved relative to one another.
The annotation crop region fully crops annotation elements when it touches any portion of the annotation element,
 so that no partial annotations are drawn.
 Annotations (such as symbols, tags, keynotes, and dimensions) that reference hidden or cropped model elements do not display in the view,
 even if they are inside the annotation crop region.
 The annotation crop region is always rectangular and at minimum occupies the same area as the rectangular model crop
 (or the corresponding rectangular boundary around the non-rectangular model crop),
 but can be offset to be bigger than the model crop in order to display more annotations.

