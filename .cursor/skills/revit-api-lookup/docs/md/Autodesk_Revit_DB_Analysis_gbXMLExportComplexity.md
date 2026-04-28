---
kind: type
id: T:Autodesk.Revit.DB.Analysis.gbXMLExportComplexity
source: html/f1e171a8-a220-13c0-a088-853f43003bb8.htm
---
# Autodesk.Revit.DB.Analysis.gbXMLExportComplexity

This enumeration specifies the level of detail of the exported analytical energy model in gbXML.
 Complex means that Curtain Walls and Curtain Systems are exported as several openings, panel by panel;
 a curtain wall with 50 panels gets exported as 50 openings. Simple means that one "huge" opening with
 the total opening area equal to the 50 panels is exported. This is more appropriate for most energy analysis.
 Mullions mean that Mullions in Curtain Walls and Systems are exported as shading surfaces. A "simplified"
 analytical shading surface is produced from a mullion based on its centerline, thickness and offset.

## Syntax (C#)
```csharp
public enum gbXMLExportComplexity
```

