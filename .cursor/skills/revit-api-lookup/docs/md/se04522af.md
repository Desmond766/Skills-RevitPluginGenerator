---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.ComputeSubcomponents(Autodesk.Revit.DB.HostObject)
source: html/47104d1f-d0d6-4903-5d16-e5f807e3acd0.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.ComputeSubcomponents Method

Splits a roof or floor element composed of planar surfaces into a set of roughly vertical extruded loops of
 uniform depth if possible.

## Syntax (C#)
```csharp
public static IList<HostObjectSubcomponentInfo> ComputeSubcomponents(
	HostObject roofOrFloor
)
```

## Parameters
- **roofOrFloor** (`Autodesk.Revit.DB.HostObject`) - The roof or floor.

## Returns
A collection of computed components.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The host object roofOrFloor must be a floor or a non face-based roof.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The roof or floor cannot be split into subcomponents by this routine. Possible reasons are, among others:
 (1) the roof or floor contains non-planar surfaces, (2) the roof or floor cannot be divided into sub-components
 of equal thickness, or (3) the roof subcomponents contain inner boundary loops.

