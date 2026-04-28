---
kind: type
id: T:Autodesk.Revit.DB.IFC.HostObjectSubcomponentInfo
source: html/3221a7c6-0d7e-c0dd-2ca8-313acd461204.htm
---
# Autodesk.Revit.DB.IFC.HostObjectSubcomponentInfo

A class that contains roof or floor slab information, calculated by ExporterIFCUtils.ComputeSubcomponents().

## Syntax (C#)
```csharp
public class HostObjectSubcomponentInfo : IDisposable
```

## Remarks
A slab is an extrusion with one outer and no inner base profile curve loops, created by
 extruding the base profile loop in the direction Plane.Normal a distance given by the Depth value.

