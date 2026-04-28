---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.ExportExtrudedSlabOpenings(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.IFC.IFCLevelInfo,Autodesk.Revit.DB.IFC.IFCAnyHandle,System.Collections.Generic.IList{Autodesk.Revit.DB.IFC.IFCAnyHandle},System.Collections.Generic.IList{System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop}},Autodesk.Revit.DB.Plane,Autodesk.Revit.DB.IFC.IFCProductWrapper)
source: html/2f301670-4ef0-22ee-9e3b-1541b33edba2.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.ExportExtrudedSlabOpenings Method

## Syntax (C#)
```csharp
public static void ExportExtrudedSlabOpenings(
	ExporterIFC exporterIFC,
	Element pElem,
	IFCLevelInfo levelInfo,
	IFCAnyHandle localPlacementAny,
	IList<IFCAnyHandle> elementSlabAnyArr,
	IList<IList<CurveLoop>> extrusionLoops,
	Plane plane,
	IFCProductWrapper pWrapper
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`)
- **pElem** (`Autodesk.Revit.DB.Element`)
- **levelInfo** (`Autodesk.Revit.DB.IFC.IFCLevelInfo`)
- **localPlacementAny** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`)
- **elementSlabAnyArr** (`System.Collections.Generic.IList < IFCAnyHandle >`)
- **extrusionLoops** (`System.Collections.Generic.IList < IList < CurveLoop >>`)
- **plane** (`Autodesk.Revit.DB.Plane`)
- **pWrapper** (`Autodesk.Revit.DB.IFC.IFCProductWrapper`)

