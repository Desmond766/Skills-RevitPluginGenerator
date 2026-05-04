---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCGeometryInfo.CreateCurveGeometryInfo(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.Transform,Autodesk.Revit.DB.XYZ,System.Boolean)
source: html/8adbbf9e-7f24-1d07-e988-ac49aac70700.htm
---
# Autodesk.Revit.DB.IFC.IFCGeometryInfo.CreateCurveGeometryInfo Method

Creates a new container object which holds IfcCurve handles processed from a Revit geometry object.

## Syntax (C#)
```csharp
public static IFCGeometryInfo CreateCurveGeometryInfo(
	ExporterIFC ExporterIFC,
	Transform lcs,
	XYZ projectionDir,
	bool planViewOnly
)
```

## Parameters
- **ExporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **lcs** (`Autodesk.Revit.DB.Transform`) - The local coordinate system that defines the plane in which the curve handles must lie.
- **projectionDir** (`Autodesk.Revit.DB.XYZ`) - The normal vector to the input plane.
- **planViewOnly** (`System.Boolean`) - True to match curves with plan view visibility only, false to match curves regardless of their plan view visibility.

## Returns
The new geometry info container.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

