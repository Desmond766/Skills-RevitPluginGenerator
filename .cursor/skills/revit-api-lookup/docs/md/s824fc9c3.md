---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.OriginatingElementName
source: html/1a69b9bb-ac0c-23f7-ea7d-df4d2450fc02.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.OriginatingElementName Property

The name for the originating Revit element.

## Syntax (C#)
```csharp
public string OriginatingElementName { get; }
```

## Remarks
Surface elements get an originating element assigned according to the below described schema, based on associative room bounding element:
 (Family Name) : (Family Type) Sample:
 Basic Wall : Cast Concrete Wall 12"

