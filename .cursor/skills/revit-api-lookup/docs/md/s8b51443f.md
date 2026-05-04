---
kind: method
id: M:Autodesk.Revit.DB.DimensionEqualityLabelFormatting.IsValidFormatOptions
source: html/6ac39a18-e036-bbcc-d02a-358992bddfb8.htm
---
# Autodesk.Revit.DB.DimensionEqualityLabelFormatting.IsValidFormatOptions Method

Checks whether a FormatOptions object is valid for the LabelType.

## Syntax (C#)
```csharp
public bool IsValidFormatOptions()
```

## Returns
True if the FormatOptions object is valid, false otherwise.

## Remarks
Only objects whose LabelType is LengthOfSegment or TotalLength can have FormatOptions assigned.

