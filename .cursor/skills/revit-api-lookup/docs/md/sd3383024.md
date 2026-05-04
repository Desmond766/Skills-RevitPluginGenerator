---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisSpace.CADObjectUniqueId
source: html/9389805f-ff4c-078b-d79f-1736b0dc3f99.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisSpace.CADObjectUniqueId Property

The unique id of the originating CAD object (model element) associated with this space.

## Syntax (C#)
```csharp
public string CADObjectUniqueId { get; }
```

## Remarks
This id can be passed to obtain the element from Document.Element[string] property, but any element obtained through this method
 may no longer point to a valid or up-to-date model element. The originating CAD object is only accurate and up-to-date at the time of creation of the energy model.

