---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetLegacyStairOrRampComponents(Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.Element)
source: html/a0aa692b-ea27-7b8a-ab52-11d14943f269.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetLegacyStairOrRampComponents Method

Gets the components of a stair or ramp.

## Syntax (C#)
```csharp
public static IFCLegacyStairOrRamp GetLegacyStairOrRampComponents(
	ExporterIFC exporterIFC,
	Element element
)
```

## Parameters
- **exporterIFC** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The exporter.
- **element** (`Autodesk.Revit.DB.Element`) - The legacy stair or ramp element.

## Returns
The LegacyStairOrRamp that contains the components. NULL means the components can't be determined.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

