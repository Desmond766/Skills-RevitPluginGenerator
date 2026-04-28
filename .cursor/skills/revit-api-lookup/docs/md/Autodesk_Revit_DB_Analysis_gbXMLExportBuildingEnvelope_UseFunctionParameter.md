---
kind: enumMember
id: F:Autodesk.Revit.DB.Analysis.gbXMLExportBuildingEnvelope.UseFunctionParameter
enum: Autodesk.Revit.DB.Analysis.gbXMLExportBuildingEnvelope
source: html/38b227f5-0d59-fef1-c617-a9ee57c80ff5.htm
---
# Autodesk.Revit.DB.Analysis.gbXMLExportBuildingEnvelope.UseFunctionParameter

This method uses the Function type parameter of Walls, Floors and Building Pads to determinate the building elements considered to be part of the building envelope.
 If a wall has one adjacent space, analytical surface originated from the wall will be classified as exterior surfaces.
 If a wall has two adjacent spaces and its function is Exterior, Foundation, Retaining, or Soffit, analytical surface originated from the wall will be classified
 as interior surfaces.
 If thw wall's function is Interior or Core Shaft, analytical surface originated from the wall will be classfied interior surfaces, regardless of the number of adjacent spaces.

