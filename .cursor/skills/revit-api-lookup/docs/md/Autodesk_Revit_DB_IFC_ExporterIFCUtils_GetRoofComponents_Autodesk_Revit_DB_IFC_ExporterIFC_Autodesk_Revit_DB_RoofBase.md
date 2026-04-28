---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetRoofComponents(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.RoofBase)
source: html/5f69588b-fe06-ca39-cf72-145e580d839b.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetRoofComponents Method

Gets the components of roof slabs.

## Syntax (C#)
```csharp
public static RoofComponents GetRoofComponents(
	ExporterIFC exporterIFC,
	RoofBase roof
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **roof** (`Autodesk.Revit.DB.RoofBase`) - The roof element.

## Returns
The roof components.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

