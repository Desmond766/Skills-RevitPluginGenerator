---
kind: property
id: P:Autodesk.Revit.DB.Infrastructure.AlignmentStationLabelSetOptions.Offset
zh: 偏移、偏移量
source: html/896fafc5-2e25-8ecb-be66-297e2a46f8b6.htm
---
# Autodesk.Revit.DB.Infrastructure.AlignmentStationLabelSetOptions.Offset Property

**中文**: 偏移、偏移量

The offset of the labels from the alignment, in Revit internal paper space units (standard Imperial feet).
 A positive offset creates labels to the right of the alignment, a negative - to the left.
 The default value is null.
 If null, a predefined offset value will be used, depending on the unit setting for stationing units in the document.
 For standard imperial, the default is 1/8".
 For survey imperial, the default is 1/8" (US survey).
 For metric, the default is 5 mm.

## Syntax (C#)
```csharp
public Nullable<double> Offset { get; set; }
```

