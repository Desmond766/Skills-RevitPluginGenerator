---
kind: method
id: M:Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.IsRecommendedTypeForSet(Autodesk.Revit.DB.Element)
source: html/df3f1355-5c15-5665-23e6-520ce91c8815.htm
---
# Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.IsRecommendedTypeForSet Method

Checks if the element type is recommended for alignment labels in sets.

## Syntax (C#)
```csharp
public static bool IsRecommendedTypeForSet(
	Element type
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.Element`) - The type element to check.

## Remarks
Can be used for finding types to be set to TypeId 
 when creating alignment label sets with CreateSet(Alignment, View, AlignmentStationLabelSetOptions) .

