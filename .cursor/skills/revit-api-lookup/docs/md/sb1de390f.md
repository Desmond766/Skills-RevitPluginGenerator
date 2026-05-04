---
kind: method
id: M:Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzer.GetBoundingElementsForSpaceVolume(System.Int32)
source: html/5e135bb1-a40e-ecf4-569d-5c8ca44f0995.htm
---
# Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzer.GetBoundingElementsForSpaceVolume Method

Returns the collection of bounding building elements for an enclosed space volume.

## Syntax (C#)
```csharp
public IList<LinkElementId> GetBoundingElementsForSpaceVolume(
	int spaceVolume
)
```

## Parameters
- **spaceVolume** (`System.Int32`)

## Returns
The ids of the bounding building elements for the enclosed space volume.

## Remarks
This method requires the building envelope analyzer method created with
 the option set to compute enclosed space volumes.

