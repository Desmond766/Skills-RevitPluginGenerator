---
kind: property
id: P:Autodesk.Revit.DB.Solid.Volume
zh: 体积
source: html/4b4088b8-2096-e7f8-d72f-fc1402592967.htm
---
# Autodesk.Revit.DB.Solid.Volume Property

**中文**: 体积

Returns the signed volume of this solid.

## Syntax (C#)
```csharp
public double Volume { get; }
```

## Returns
The real number equal to the signed volume of this solid.

## Remarks
Revit attempts to compute the volume analytically, if possible. If an analytical solution is not possible,
it uses tessellated faces to calculate a reasonable approximation for the volume. 
The calculated volume may be slightly underestimated or overestimated if curved surfaces are present.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this solid is not a valid Geometry object or the volume calculation failed.

