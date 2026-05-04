---
kind: property
id: P:Autodesk.Revit.DB.SolidOrShellTessellationControls.MinExternalAngleBetweenTriangles
source: html/efe2c10a-1261-86da-baf5-3fcd482e6ff2.htm
---
# Autodesk.Revit.DB.SolidOrShellTessellationControls.MinExternalAngleBetweenTriangles Property

A positive real number specifying the minimum allowed value for the external angle between two adjacent triangles, in radians.

## Syntax (C#)
```csharp
public double MinExternalAngleBetweenTriangles { get; set; }
```

## Remarks
A small value yields more smoothly curved triangulated surfaces, usually at the expense of an increase in the
 number of triangles. Note that this setting has no effect for planar surfaces. This constraint may be approximately
 enforced.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for minExternalAngleBetweenTriangles must be greater than 0 and no more than 30000 feet.

