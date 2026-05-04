---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetLegacyStairsProperties(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.Element,System.Int32@,System.Int32@,System.Double@,System.Double@,System.Double@,System.Double@,System.Double@)
source: html/e93b7570-0538-6eac-dd03-abab96e12fb4.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetLegacyStairsProperties Method

Returns one or more properties for legacy (created in R2012 or before) Stairs.

## Syntax (C#)
```csharp
public static void GetLegacyStairsProperties(
	ExporterIFC exporterIFC,
	Element pElement,
	out int pNumRisers,
	out int pNumTreads,
	out double pRiserHeight,
	out double pTreadLength,
	out double pMinTreadLength,
	out double pNosingLength,
	out double pWaistThickness
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **pElement** (`Autodesk.Revit.DB.Element`) - the legacy stair.
- **pNumRisers** (`System.Int32 %`) - Number of Risers in the Stair.
- **pNumTreads** (`System.Int32 %`) - Number of Treads in the Stair.
- **pRiserHeight** (`System.Double %`) - Riser Height of the risers in the Stair.
- **pTreadLength** (`System.Double %`) - Tread length of the treads in the Stair.
- **pMinTreadLength** (`System.Double %`) - Minimum Tread length of the treads in the Stair.
- **pNosingLength** (`System.Double %`) - Nosing length of the treads in the Stair.
- **pWaistThickness** (`System.Double %`) - Waist thickness of the flight of stair.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

