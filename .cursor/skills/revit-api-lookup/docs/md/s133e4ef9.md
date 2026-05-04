---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCGeometryInfo.CreateFaceGeometryInfo(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.Plane,Autodesk.Revit.DB.XYZ,System.Double,System.Boolean)
source: html/ac4f4f60-c2dc-57bb-03ad-29c67e13e50c.htm
---
# Autodesk.Revit.DB.IFC.IFCGeometryInfo.CreateFaceGeometryInfo Method

Creates a new container object which holds IfcFace handles processed from a Revit geometry object.

## Syntax (C#)
```csharp
public static IFCGeometryInfo CreateFaceGeometryInfo(
	ExporterIFC ExporterIFC,
	Plane Plane,
	XYZ ProjDir,
	double epsilon,
	bool createRepresentations
)
```

## Parameters
- **ExporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **Plane** (`Autodesk.Revit.DB.Plane`) - The plane in which the face handles must lie.
- **ProjDir** (`Autodesk.Revit.DB.XYZ`) - The normal vector to the input plane.
- **epsilon** (`System.Double`) - The epsilon value used to process surfaces.
- **createRepresentations** (`System.Boolean`) - Indicates if this should also create geometry representation handles.

## Returns
The new geometry info container.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

