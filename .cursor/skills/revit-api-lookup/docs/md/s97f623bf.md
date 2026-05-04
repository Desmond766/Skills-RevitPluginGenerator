---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.ExportSlabAsExtrusion(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.GeometryElement,Autodesk.Revit.DB.IFC.IFCTransformSetter,Autodesk.Revit.DB.IFC.IFCAnyHandle,System.Collections.Generic.IList{Autodesk.Revit.DB.IFC.IFCAnyHandle}@,System.Collections.Generic.IList{Autodesk.Revit.DB.IFC.IFCAnyHandle}@,System.Collections.Generic.IList{System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop}}@,System.Collections.Generic.IList{Autodesk.Revit.DB.IFC.IFCExtrusionCreationData}@,Autodesk.Revit.DB.Plane)
source: html/fe8e843c-67c8-d047-6d2d-42fd11ebd2d5.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.ExportSlabAsExtrusion Method

## Syntax (C#)
```csharp
public static bool ExportSlabAsExtrusion(
	ExporterIFC exporterIFC,
	Element pCeilingAndFloor,
	GeometryElement pGRep,
	IFCTransformSetter pTmpTrfSetter,
	IFCAnyHandle localPlacement,
	out IList<IFCAnyHandle> localPlacementAnyArr,
	out IList<IFCAnyHandle> reps,
	out IList<IList<CurveLoop>> extrusionLoops,
	out IList<IFCExtrusionCreationData> loopExtraParams,
	Plane plane
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`)
- **pCeilingAndFloor** (`Autodesk.Revit.DB.Element`)
- **pGRep** (`Autodesk.Revit.DB.GeometryElement`)
- **pTmpTrfSetter** (`Autodesk.Revit.DB.IFC.IFCTransformSetter`)
- **localPlacement** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`)
- **localPlacementAnyArr** (`System.Collections.Generic.IList < IFCAnyHandle > %`)
- **reps** (`System.Collections.Generic.IList < IFCAnyHandle > %`)
- **extrusionLoops** (`System.Collections.Generic.IList < IList < CurveLoop >> %`)
- **loopExtraParams** (`System.Collections.Generic.IList < IFCExtrusionCreationData > %`)
- **plane** (`Autodesk.Revit.DB.Plane`)

