---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.OriginatingElementDescription
source: html/16789bde-6a3a-7a7c-f90c-ac4982a76a71.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.OriginatingElementDescription Property

The description for the originating Revit element.

## Syntax (C#)
```csharp
public string OriginatingElementDescription { get; }
```

## Remarks
Surface and Opening elements get an originating element assigned
 according to the below described schema, based on associative
 room bounding element:
 (Family Name): (Family Type)[Element Id] Sample:
 Basic Wall: Cast Concrete Wall 12" [49749]

