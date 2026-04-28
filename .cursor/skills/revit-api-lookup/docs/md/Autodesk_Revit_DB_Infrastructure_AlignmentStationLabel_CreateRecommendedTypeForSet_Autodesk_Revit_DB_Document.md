---
kind: method
id: M:Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.CreateRecommendedTypeForSet(Autodesk.Revit.DB.Document)
source: html/39150210-06f8-595d-d255-879d7e2e25e3.htm
---
# Autodesk.Revit.DB.Infrastructure.AlignmentStationLabel.CreateRecommendedTypeForSet Method

Creates an element type recommended for alignment label sets and returns its ElementId.

## Syntax (C#)
```csharp
public static ElementId CreateRecommendedTypeForSet(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the type will be created.

## Remarks
The crucial features of the label type recommended for sets are:
 - rotate with component
 - vertical text
 - label display includes station value
 - leader arrow head has type "Heavy End Tick Mark"

