---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisOpening.OriginatingElementDescription
source: html/b931dd0f-f901-0a8a-5acb-b7338f88e7f7.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisOpening.OriginatingElementDescription Property

The description for the originating Revit element.

## Syntax (C#)
```csharp
public string OriginatingElementDescription { get; }
```

## Remarks
Surface and Opening elements get an CADObjectId element assigned
 according to the below described schema, based on associative
 room bounding element:
(Family Name): (Family Type)[Element Id] 
Sample:
 System Panel: System Panel [50566]

