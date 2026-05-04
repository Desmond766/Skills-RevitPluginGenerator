---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCExtrusionCalculatorUtils.CalculateExtrusionData(Autodesk.Revit.DB.IFC.IFCExtrusionCalculatorOptions,Autodesk.Revit.DB.GeometryObject)
source: html/2586cb51-7d19-2f3a-d4e6-cc9cfc913a3c.htm
---
# Autodesk.Revit.DB.IFC.IFCExtrusionCalculatorUtils.CalculateExtrusionData Method

Calculates the extrusion data from a Revit geometry object.

## Syntax (C#)
```csharp
public static IList<IFCExtrusionData> CalculateExtrusionData(
	IFCExtrusionCalculatorOptions extrusionOptions,
	GeometryObject geometryObject
)
```

## Parameters
- **extrusionOptions** (`Autodesk.Revit.DB.IFC.IFCExtrusionCalculatorOptions`) - The options for extrusion extraction.
- **geometryObject** (`Autodesk.Revit.DB.GeometryObject`) - The geometry object.

## Returns
A collection of extrusion data calculated for the geometry.
 If the function fails to calculate one or more valid extrusions,
 this collection will be empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

