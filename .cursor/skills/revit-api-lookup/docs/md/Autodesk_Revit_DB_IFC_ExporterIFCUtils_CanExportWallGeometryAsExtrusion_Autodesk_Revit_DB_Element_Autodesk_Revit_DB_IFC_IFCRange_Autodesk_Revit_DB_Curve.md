---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.CanExportWallGeometryAsExtrusion(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.IFC.IFCRange,Autodesk.Revit.DB.Curve)
source: html/4f4851f4-1675-476c-0061-f9299b3b00cf.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.CanExportWallGeometryAsExtrusion Method

Identifies if the base geometry of the wall can be represented as an extrusion.

## Syntax (C#)
```csharp
public static bool CanExportWallGeometryAsExtrusion(
	Element element,
	IFCRange range,
	Curve curve
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The wall or in-place wall element.
- **range** (`Autodesk.Revit.DB.IFC.IFCRange`) - The range. This consists of two double values representing the height in Z at the start and the end
 of the range. If the values are identical the entire wall is used.
- **curve** (`Autodesk.Revit.DB.Curve`) - The wall's base curve.

## Returns
True if the wall export can be made in the form of an extrusion, false if the
 geometry cannot be assigned to an extrusion.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

