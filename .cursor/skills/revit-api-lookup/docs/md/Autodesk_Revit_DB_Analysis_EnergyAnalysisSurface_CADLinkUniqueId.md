---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.CADLinkUniqueId
source: html/208694d5-422f-68e9-76e5-741095383624.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.CADLinkUniqueId Property

The unique id of the originating CAD object's link (linked document) associated with this surface.

## Syntax (C#)
```csharp
public string CADLinkUniqueId { get; }
```

## Remarks
This id can be passed to obtain the element from Document.Element[string] property, but any link obtained through this method
 may no longer be a valid or up-to-date link. The originating CAD link is only accurate and up-to-date at the time of creation of the energy model.
 An empty string is returned if the originating CAD object is not hosted in a linked document.

