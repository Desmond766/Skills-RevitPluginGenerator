---
kind: enumMember
id: F:Autodesk.Revit.DB.Analysis.gbXMLExportComplexity.Simple
enum: Autodesk.Revit.DB.Analysis.gbXMLExportComplexity
source: html/f1e171a8-a220-13c0-a088-853f43003bb8.htm
---
# Autodesk.Revit.DB.Analysis.gbXMLExportComplexity.Simple

Curtain Walls and Curtain Systems are normally exported as several openings, panel by panel,
 while for energy analysis all you need is one giant window. A curtain wall with 50 panels
 gets exported as 50 openings, while 1 opening with the total opening area would be more appropriate.
 Using this enumeration, one "large" window/opening will be exported for a curtain wall/system

