---
kind: method
id: M:Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.CreateSet(Autodesk.Revit.DB.Infrastructure.Alignment,Autodesk.Revit.DB.View,Autodesk.Revit.DB.Infrastructure.AlignmentStationLabelSetOptions)
source: html/bbb3fb20-cbc6-f6aa-cc23-ae7ad73747b3.htm
---
# Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.CreateSet Method

Creates a collection of AlignmentStationLabel objects along with their underlying SpotDimension elements.

## Syntax (C#)
```csharp
public static ICollection<AlignmentStationLabel> CreateSet(
	Alignment alignment,
	View view,
	AlignmentStationLabelSetOptions options
)
```

## Parameters
- **alignment** (`Autodesk.Revit.DB.Infrastructure.Alignment`) - The alignment on which the alignment station label is placed.
- **view** (`Autodesk.Revit.DB.View`) - The view for which the alignment station label is created.
- **options** (`Autodesk.Revit.DB.Infrastructure.AlignmentStationLabelSetOptions`) - The alignment station options of the label set to be created.

