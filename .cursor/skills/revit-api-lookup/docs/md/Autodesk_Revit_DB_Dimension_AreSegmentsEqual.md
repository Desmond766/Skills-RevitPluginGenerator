---
kind: property
id: P:Autodesk.Revit.DB.Dimension.AreSegmentsEqual
zh: 尺寸标注、标注
source: html/0d28a47a-b40e-c0fc-bfe0-d1b391f2c176.htm
---
# Autodesk.Revit.DB.Dimension.AreSegmentsEqual Property

**中文**: 尺寸标注、标注

Indicates if all segments are forced to be equal.

## Syntax (C#)
```csharp
public bool AreSegmentsEqual { get; set; }
```

## Remarks
This property is usable only for linear dimensions with more
than one segment.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the dimension is non-linear or has only one segment.

