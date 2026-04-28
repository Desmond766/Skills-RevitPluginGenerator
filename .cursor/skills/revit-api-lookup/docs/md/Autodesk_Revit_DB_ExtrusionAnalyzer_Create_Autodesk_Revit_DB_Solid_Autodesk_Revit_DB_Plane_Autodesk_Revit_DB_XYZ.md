---
kind: method
id: M:Autodesk.Revit.DB.ExtrusionAnalyzer.Create(Autodesk.Revit.DB.Solid,Autodesk.Revit.DB.Plane,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/60f25f96-c3f8-8191-a0a9-d298fe5cd10f.htm
---
# Autodesk.Revit.DB.ExtrusionAnalyzer.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates an ExtrusionAnalyzer and computes and stores the solid's shadow.

## Syntax (C#)
```csharp
public static ExtrusionAnalyzer Create(
	Solid solidGeometry,
	Plane plane,
	XYZ direction
)
```

## Parameters
- **solidGeometry** (`Autodesk.Revit.DB.Solid`) - The geometry to analyze.
- **plane** (`Autodesk.Revit.DB.Plane`) - The plane to use for the base plane for the extrusion.
- **direction** (`Autodesk.Revit.DB.XYZ`) - The direction to use for the calculation for the extrusion.
 The direction must be transverse to the base plane.

## Returns
The newly created ExtrusionAnalyzer object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input direction must be transverse to the input plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - A failure occurred in creating the ExtrusionAnalyzer or computing the solid's shadow.

