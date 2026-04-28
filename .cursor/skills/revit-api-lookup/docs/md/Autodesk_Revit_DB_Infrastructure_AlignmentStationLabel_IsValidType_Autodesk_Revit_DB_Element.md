---
kind: method
id: M:Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.IsValidType(Autodesk.Revit.DB.Element)
source: html/ff11b964-e6e7-9dad-fbf1-461244fcf010.htm
---
# Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.IsValidType Method

Checks if the type is a valid alignment station label type.

## Syntax (C#)
```csharp
public static bool IsValidType(
	Element type
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.Element`) - The element type to validate.

## Remarks
Can be used for finding or types to be set to TypeId 
 when creating alignment label sets with Create(Alignment, View, AlignmentStationLabelOptions) ;
 or types to be set to TypeId 
 when creating alignment labels with CreateSet(Alignment, View, AlignmentStationLabelSetOptions) .

