---
kind: property
id: P:Autodesk.Revit.DB.HostedSweep.ReferenceCurve(Autodesk.Revit.DB.Reference)
source: html/76c8b986-670c-1d4a-3ae4-776b3eb29ad9.htm
---
# Autodesk.Revit.DB.HostedSweep.ReferenceCurve Property

The curve on which the hosted sweep segment is created.

## Syntax (C#)
```csharp
public Curve this[
	Reference targetRef
] { get; }
```

## Parameters
- **targetRef** (`Autodesk.Revit.DB.Reference`) - Reference of the curve that hosts the object.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration fails.

