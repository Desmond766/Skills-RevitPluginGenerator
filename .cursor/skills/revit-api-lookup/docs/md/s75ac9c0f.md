---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.AddClippingsToBaseExtrusion(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.Wall,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.IFC.IFCRange,Autodesk.Revit.DB.IFC.IFCRange,Autodesk.Revit.DB.IFC.IFCAnyHandle,System.Collections.Generic.IList{Autodesk.Revit.DB.IFC.IFCExtrusionData}@)
source: html/f477a65c-ef52-e51c-6f16-8a6e69545c08.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.AddClippingsToBaseExtrusion Method

## Syntax (C#)
```csharp
public static IFCAnyHandle AddClippingsToBaseExtrusion(
	ExporterIFC exporterIFC,
	Wall wall,
	XYZ setterOffset,
	IFCRange range,
	IFCRange zSpan,
	IFCAnyHandle baseBodyItemHandle,
	out IList<IFCExtrusionData> pCutPairOpenings
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`)
- **wall** (`Autodesk.Revit.DB.Wall`)
- **setterOffset** (`Autodesk.Revit.DB.XYZ`)
- **range** (`Autodesk.Revit.DB.IFC.IFCRange`)
- **zSpan** (`Autodesk.Revit.DB.IFC.IFCRange`)
- **baseBodyItemHandle** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`)
- **pCutPairOpenings** (`System.Collections.Generic.IList < IFCExtrusionData > %`)

