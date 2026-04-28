---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisOpening.CADLinkUniqueId
source: html/98e49dad-862f-4e26-4805-882dfc98dfb8.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisOpening.CADLinkUniqueId Property

The unique id of the originating CAD object's link (linked document) associated with this opening.

## Syntax (C#)
```csharp
public string CADLinkUniqueId { get; }
```

## Remarks
This id can be passed to obtain the element from Document.Element[string] property, but any link obtained through this method
 may no longer be a valid or up-to-date link. The originating CAD link is only accurate and up-to-date at the time of creation of the energy model.
 An empty string is returned if the originating CAD object is not hosted in a linked document.

