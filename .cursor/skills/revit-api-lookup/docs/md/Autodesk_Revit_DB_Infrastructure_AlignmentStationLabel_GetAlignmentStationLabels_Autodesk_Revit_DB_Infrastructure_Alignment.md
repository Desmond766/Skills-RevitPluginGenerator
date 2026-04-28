---
kind: method
id: M:Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.GetAlignmentStationLabels(Autodesk.Revit.DB.Infrastructure.Alignment)
source: html/0cae55cf-ef69-817a-d284-65f2141761f9.htm
---
# Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.GetAlignmentStationLabels Method

Returns all alignment station labels placed on the given alignment.

## Syntax (C#)
```csharp
public static ICollection<AlignmentStationLabel> GetAlignmentStationLabels(
	Alignment alignment
)
```

## Parameters
- **alignment** (`Autodesk.Revit.DB.Infrastructure.Alignment`) - The alignment for which the labels are returned.

## Remarks
The resulting collection may contain both "individual" labels (created via Create(Alignment, View, AlignmentStationLabelOptions) )
 and "labels in set" (created via CreateSet(Alignment, View, AlignmentStationLabelSetOptions) ).
 These labels have categories respectively OST_Alignments and OST_AlignmentStationLabelSets .

