---
kind: type
id: T:Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModel
source: html/858aed23-8a94-a70a-c1fc-ca03523e2f02.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModel

Manage the analytical thermal model.

## Syntax (C#)
```csharp
public class EnergyAnalysisDetailModel : Element
```

## Remarks
The Export to gbXML and the Heating and Cooling Loads features
 produces an analytical thermal model from the physical model
 of a building. The analytical thermal model is composed of
 spaces, zones and planar surfaces that represent the actual
 volumetric elements of the building.
 If there are currently no EnergyAnalysisDetailModel elements in
 the document, when the first one is generated it will be considered
 the persistent energy model (and maybe removed and recreated by
 actions the user takes in the UI). If there is already a persistent
 EnergyAnalysisDetailModel element in the document, the API can
 generate other independent energy models, but they will not be
 affected by the actions the user takes in the UI.
 The EnergyAnalysisDetailModel will remain in the document until
 it is discarded (either by the actions of the user, or by a call
 to Document.Delete() ).

