---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCFile.CreateStyle(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.IFC.IFCAnyHandle)
source: html/a01806c3-4ee3-965e-7aa1-5aaa35dc7420.htm
---
# Autodesk.Revit.DB.IFC.IFCFile.CreateStyle Method

Creates and populates an IfcStyledItem for an IfcRepresentationItem with a IfcSurfaceStyle, IfcCurveStyle, and/or an IfcFillStyle,
 and assigns them to the file.

## Syntax (C#)
```csharp
public IFCAnyHandle CreateStyle(
	ExporterIFC exporterIFC,
	IFCAnyHandle repItem
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **repItem** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The representation item.

## Returns
The handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - A transaction is required for this operation.

