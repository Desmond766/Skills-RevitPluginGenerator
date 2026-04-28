---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisOpening.Type
zh: 类型
source: html/b23c3e9f-5abb-4b24-1f5c-40eec68a05f0.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisOpening.Type Property

**中文**: 类型

The gbXML opening type attribute.

## Syntax (C#)
```csharp
public gbXMLOpeningType Type { get; }
```

## Remarks
The type of the opening is based on the family category for
 the opening and in what element it is contained in:
 If it is a Window it will have a type of OperableWindow. If it is a Door it will have a type of NonSlidingDoor. If the opening is contained in a Roof it will have a type of FixedSkylight. If it is a Curtain Wall Panel, the opening will default to
 a type of FixedWindow. If the material specified for the family,
 and the material transparency is less than 3%, the opening will
 be ignored as a solid panel. 
 An opening of the category Openings will have the type of Air.

