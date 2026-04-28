---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.GetOrCreateFillPattern(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Color,System.Double)
source: html/13faad3d-86f3-ed60-b3a3-78504c969716.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.GetOrCreateFillPattern Method

Get (or create) the IfcFillPatternStyle associated with an ElementId.

## Syntax (C#)
```csharp
public IFCAnyHandle GetOrCreateFillPattern(
	ElementId fillPatternId,
	Color color,
	double planScale
)
```

## Parameters
- **fillPatternId** (`Autodesk.Revit.DB.ElementId`) - The fill pattern id.
- **color** (`Autodesk.Revit.DB.Color`) - The pattern color.
- **planScale** (`System.Double`) - The view scale.

## Returns
The IfcSurfaceStyle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

