---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.IsWallCompletelyClipped(Autodesk.Revit.DB.Wall,Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.IFC.IFCRange)
source: html/8cd5eadb-d7a8-fd52-010a-9ec394683f7c.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.IsWallCompletelyClipped Method

Determines if the input wall is completely removed by interaction with other elements
 within the given range.

## Syntax (C#)
```csharp
public static bool IsWallCompletelyClipped(
	Wall pVWall,
	ExporterIFC exporterIFC,
	IFCRange range
)
```

## Parameters
- **pVWall** (`Autodesk.Revit.DB.Wall`) - The wall.
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **range** (`Autodesk.Revit.DB.IFC.IFCRange`) - The range. This consists of two double values representing the height in Z at the start and the end
 of the range. If the values are identical the entire wall is used.

## Returns
True if the wall should be ignored within the given range.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

