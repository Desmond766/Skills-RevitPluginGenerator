---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewExtrusionRoof(Autodesk.Revit.DB.CurveArray,Autodesk.Revit.DB.ReferencePlane,Autodesk.Revit.DB.Level,Autodesk.Revit.DB.RoofType,System.Double,System.Double)
zh: 文档、文件
source: html/d165a352-dbd4-a7a5-9734-5423bbfa2543.htm
---
# Autodesk.Revit.Creation.Document.NewExtrusionRoof Method

**中文**: 文档、文件

Creates a new Extrusion Roof.

## Syntax (C#)
```csharp
public ExtrusionRoof NewExtrusionRoof(
	CurveArray profile,
	ReferencePlane refPlane,
	Level level,
	RoofType roofType,
	double extrusionStart,
	double extrusionEnd
)
```

## Parameters
- **profile** (`Autodesk.Revit.DB.CurveArray`) - The profile of the extrusion roof. The curves of the profile must be contiguous and form one open loop without self-intersections. The profile curves must lie in the %refPlane% parallel to z-axis.
- **refPlane** (`Autodesk.Revit.DB.ReferencePlane`) - The work plane for the extrusion roof. It must be parallel to z-axis.
- **level** (`Autodesk.Revit.DB.Level`) - The level of the extrusion roof.
- **roofType** (`Autodesk.Revit.DB.RoofType`) - Type of the extrusion roof.
- **extrusionStart** (`System.Double`) - Start the extrusion. Measured from %refPlane% in the direction of the plane normal.
- **extrusionEnd** (`System.Double`) - End the extrusion. Measured from %refPlane% in the direction of the plane normal.

## Remarks
This method will regenerate the document even in manual regeneration mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the work plane does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the level does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the roof type does not exist in the given document.

