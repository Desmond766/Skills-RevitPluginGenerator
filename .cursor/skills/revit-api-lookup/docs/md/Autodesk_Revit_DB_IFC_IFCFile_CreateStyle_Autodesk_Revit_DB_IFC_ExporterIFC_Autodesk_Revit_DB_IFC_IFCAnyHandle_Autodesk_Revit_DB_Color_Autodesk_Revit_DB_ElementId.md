---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCFile.CreateStyle(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.IFC.IFCAnyHandle,Autodesk.Revit.DB.Color,Autodesk.Revit.DB.ElementId)
source: html/a45ca73e-62ba-1e45-2810-9d0998f39920.htm
---
# Autodesk.Revit.DB.IFC.IFCFile.CreateStyle Method

Creates and populates an IfcStyledItem for an IfcRepresentationItem with a IfcSurfaceStyle, IfcCurveStyle, and/or an IfcFillStyle,
 and assigns them to the file.

## Syntax (C#)
```csharp
public IFCAnyHandle CreateStyle(
	ExporterIFC exporterIFC,
	IFCAnyHandle repItem,
	Color color,
	ElementId fillPatternId
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **repItem** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The representation item.
- **color** (`Autodesk.Revit.DB.Color`) - The color.
- **fillPatternId** (`Autodesk.Revit.DB.ElementId`) - The fill pattern id.

## Returns
The handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - A transaction is required for this operation.

