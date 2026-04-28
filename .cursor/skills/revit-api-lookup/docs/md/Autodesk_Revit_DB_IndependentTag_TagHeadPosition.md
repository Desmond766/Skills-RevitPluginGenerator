---
kind: property
id: P:Autodesk.Revit.DB.IndependentTag.TagHeadPosition
zh: 标记、打标、标签
source: html/4f49d3f3-e5c5-108a-49dd-2a36697bd08e.htm
---
# Autodesk.Revit.DB.IndependentTag.TagHeadPosition Property

**中文**: 标记、打标、标签

The position of the head of tag in model coordinates.

## Syntax (C#)
```csharp
public XYZ TagHeadPosition { get; set; }
```

## Remarks
The depth of the tag head position in the view does not matter
 because tags are drawn over model geometry in the view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

