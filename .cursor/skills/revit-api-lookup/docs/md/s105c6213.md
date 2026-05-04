---
kind: type
id: T:Autodesk.Revit.DB.Analysis.MassLevelData
source: html/c1e62aaf-b7af-ad0c-60d5-4a1a9c1bed79.htm
---
# Autodesk.Revit.DB.Analysis.MassLevelData

MassLevelData is a conceptual representation of an occupiable floor (Mass Floor) in a conceptual building model.
 It is defined by associating a particular level with a particular mass element in a Revit project.

## Syntax (C#)
```csharp
public class MassLevelData : Element
```

## Remarks
MassLevelData reports metrics, such as floor areas, related to conceptual space planning.
 MassLevelData contains information, such as ConceptualConstructionType, used as part of the
 Conceptual Energy Analytical model.
 The MassLevel data geometry is determined by combining all the geometry of a mass into a single geometry, and then
 taking the area of intersection with the level of the MassLevelData.

