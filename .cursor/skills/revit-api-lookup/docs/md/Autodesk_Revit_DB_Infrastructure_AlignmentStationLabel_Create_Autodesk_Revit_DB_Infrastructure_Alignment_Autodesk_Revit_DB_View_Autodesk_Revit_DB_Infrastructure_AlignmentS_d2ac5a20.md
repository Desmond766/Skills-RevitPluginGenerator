---
kind: method
id: M:Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.Create(Autodesk.Revit.DB.Infrastructure.Alignment,Autodesk.Revit.DB.View,Autodesk.Revit.DB.Infrastructure.AlignmentStationLabelOptions)
zh: 创建、新建、生成、建立、新增
source: html/eb69d2d4-5a55-6402-ae7b-d1049fdba2d4.htm
---
# Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates an AlignmentStationLabel object along with its underlying SpotDimension element. 
 Returns null if element creation fails.

## Syntax (C#)
```csharp
public static AlignmentStationLabel Create(
	Alignment alignment,
	View view,
	AlignmentStationLabelOptions options
)
```

## Parameters
- **alignment** (`Autodesk.Revit.DB.Infrastructure.Alignment`) - The alignment on which the alignment station label is placed.
- **view** (`Autodesk.Revit.DB.View`) - The view for which the alignment station label is created.
- **options** (`Autodesk.Revit.DB.Infrastructure.AlignmentStationLabelOptions`) - The alignment station options of the label to be created.

