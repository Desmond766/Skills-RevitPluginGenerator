---
kind: property
id: P:Autodesk.Revit.DB.Dimension.Segments
zh: 尺寸标注、标注
source: html/d7fcdab2-ca81-0ed1-4813-f7aa092430d7.htm
---
# Autodesk.Revit.DB.Dimension.Segments Property

**中文**: 尺寸标注、标注

The segments in the dimension.

## Syntax (C#)
```csharp
public DimensionSegmentArray Segments { get; }
```

## Remarks
Returns a read only array of segments in the dimension.
The references of the dimension can be mapped to segments in order.
The first segment here wrapped by first and second references;
the nth segment is wrapped by nth and n+1st references.

