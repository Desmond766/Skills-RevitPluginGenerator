---
kind: method
id: M:Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzer.GetCenterPointsForConnectedGridCellsInSpaceVolume(System.Int32)
source: html/375faa57-9d9c-75dc-ccb2-f0e70b957b11.htm
---
# Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzer.GetCenterPointsForConnectedGridCellsInSpaceVolume Method

Returns the collection of connected cells in an enclosed space volume.

## Syntax (C#)
```csharp
public IList<XYZ> GetCenterPointsForConnectedGridCellsInSpaceVolume(
	int spaceVolume
)
```

## Parameters
- **spaceVolume** (`System.Int32`)

## Returns
The center points for the connected analytical grid cells in the enclosed space volume.

## Remarks
This method requires the building envelope analyzer method created with
 the option set to compute enclosed space volumes.

