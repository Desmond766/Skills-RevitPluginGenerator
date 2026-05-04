---
kind: method
id: M:Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.GetAlignmentStationLabels(Autodesk.Revit.DB.Infrastructure.Alignment,Autodesk.Revit.DB.ElementId)
source: html/e078bd76-8b9d-d02b-5fb7-ddfafa988f65.htm
---
# Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.GetAlignmentStationLabels Method

Returns all alignment station labels placed on the given alignment in the given view.

## Syntax (C#)
```csharp
public static ICollection<AlignmentStationLabel> GetAlignmentStationLabels(
	Alignment alignment,
	ElementId viewId
)
```

## Parameters
- **alignment** (`Autodesk.Revit.DB.Infrastructure.Alignment`) - The alignment for which the labels are returned.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the view for which the labels are returned.

## Remarks
The resulting collection may contain both "individual" labels (created via Create(Alignment, View, AlignmentStationLabelOptions) )
 and "labels in set" (created via CreateSet(Alignment, View, AlignmentStationLabelSetOptions) ).
 These labels have categories respectively OST_Alignments and OST_AlignmentStationLabelSets .

