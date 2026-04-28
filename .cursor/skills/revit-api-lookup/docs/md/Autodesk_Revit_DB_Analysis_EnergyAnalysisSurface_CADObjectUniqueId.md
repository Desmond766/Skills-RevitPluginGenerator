---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.CADObjectUniqueId
source: html/2b0775ef-a303-a5ea-e592-97f8f407fb47.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.CADObjectUniqueId Property

The unique id of the originating CAD object (model element) associated with this surface.

## Syntax (C#)
```csharp
public string CADObjectUniqueId { get; }
```

## Remarks
This id can be passed to obtain the element from Document.Element[string] property, but any element obtained through this method
 may no longer be a valid or up-to-date model element. The originating CAD object is only accurate and up-to-date at the time of creation of the energy model.
 If the originating element belongs to a linked document, the unique id of the link obtained from CADLinkUniqueId should be used to access it.

