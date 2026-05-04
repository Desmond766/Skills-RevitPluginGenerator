---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.Type
zh: 类型
source: html/ba638150-4be5-979d-15f4-e2885eb77c4b.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.Type Property

**中文**: 类型

The gbXML surface type attribute.

## Syntax (C#)
```csharp
public gbXMLSurfaceType Type { get; }
```

## Remarks
The type of surface is figured out depending on the source element and the number of space adjacencies.
 If there is no associate source element and no space adjacencies, it will have a type of Shade. If there are any space adjacencies, it will have a type of Air. If the source element is a Wall or a Curtain Wall and have one space adjacency, it will have a type of ExteriorWall. If the source element is a Wall or a Curtain Wall and have two space adjacencies, it will have a type of InteriorWall. If the source element is a Wall or a Curtain Wall and the type Function parameter is set to "Interior" or "CoreShaft", it will have a type of InteriorWall. If the source element is a Wall or a Curtain Wall and have one space adjacency and if it is below grade, it will have a type of UndergroundWall. If the source element is a Floor and have one space adjacency, it will have a type of SlabOnGrade. If the source element is above grade, it will have
 a type of RaisedFloor. If the source element is below grade, it will have a type of UndergroundSlab. If the source element is a Floor and have two space adjacencies, it will have a type of InteriorFloor. If the source element is a Floor and the type Function parameter is set to "Interior", it will have a type of InteriorFloor. If the source element is a Roof or a Ceiling and have one space adjacency, it will have a type of Roof. If the source element is a Roof or a Ceiling and have one space adjacency and is below grade, it will have a type of UndergroundCeiling. If the source element is a Roof or a Ceiling and have two space adjacencies, it will have a type of Ceiling.

