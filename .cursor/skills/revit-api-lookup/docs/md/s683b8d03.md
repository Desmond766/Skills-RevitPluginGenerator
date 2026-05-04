---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.CollectGeometryInfo(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.IFC.IFCGeometryInfo,Autodesk.Revit.DB.GeometryObject,Autodesk.Revit.DB.XYZ,System.Boolean)
source: html/3cc86cde-7898-e314-2eb2-fd9fc0c9a895.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.CollectGeometryInfo Method

Collects all the target geometry from the input geometry object and adds it as IFC handles
 to the IFCInfo.

## Syntax (C#)
```csharp
public static void CollectGeometryInfo(
	ExporterIFC exporterIFC,
	IFCGeometryInfo geometryInfo,
	GeometryObject gNode,
	XYZ offset,
	bool forceVisible
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **geometryInfo** (`Autodesk.Revit.DB.IFC.IFCGeometryInfo`) - The container object which collects the geometry.
- **gNode** (`Autodesk.Revit.DB.GeometryObject`) - The geometry object to be processed.
- **offset** (`Autodesk.Revit.DB.XYZ`) - The offset to apply to each of the collected geometry handles.
- **forceVisible** (`System.Boolean`) - True to process geometry which is not set as visible. False to only process visible geometry.

## Remarks
The type of geometry collected is determined by the method of creation for the IFCGeometryInfo.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

