---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCExtrusionCalculatorOptions.#ctor(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.IFC.IFCExtrusionAxes,Autodesk.Revit.DB.XYZ,System.Double)
source: html/66d3d7fd-aa11-7140-c013-893ded5b8fbf.htm
---
# Autodesk.Revit.DB.IFC.IFCExtrusionCalculatorOptions.#ctor Method

Constructs a new instance of a class used to calculate extrusions from Revit geometry.

## Syntax (C#)
```csharp
public IFCExtrusionCalculatorOptions(
	ExporterIFC exporterIFC,
	IFCExtrusionAxes extrusionAxes,
	XYZ customAxis,
	double scale
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **extrusionAxes** (`Autodesk.Revit.DB.IFC.IFCExtrusionAxes`) - The extrusion axes to try when doing the calculation.
- **customAxis** (`Autodesk.Revit.DB.XYZ`) - The custom axis to try (if extrusionAxes includes an option for a custom direction).
- **scale** (`System.Double`) - The scaling factor for length measurements from the default Revit units to the export units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

