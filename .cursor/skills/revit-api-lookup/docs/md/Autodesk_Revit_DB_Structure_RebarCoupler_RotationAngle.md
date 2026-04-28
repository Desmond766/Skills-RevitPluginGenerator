---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarCoupler.RotationAngle
source: html/8594c93b-b0a0-ef01-22b8-1574aa3a6634.htm
---
# Autodesk.Revit.DB.Structure.RebarCoupler.RotationAngle Property

Indetifies the rotation angle of the coupler around its axis.

## Syntax (C#)
```csharp
public double RotationAngle { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The rotation parameter cannot be set or get for Self-Orienting rebar coupler families ( rebar coupler families with FAMILY_SELF_ORIENTING parameter = 1 ).

