---
kind: property
id: P:Autodesk.Revit.DB.MeshFromGeometryOperationResult.HasInvalidData
source: html/2ceba862-dbcf-348e-4aec-9e676a093d60.htm
---
# Autodesk.Revit.DB.MeshFromGeometryOperationResult.HasInvalidData Property

Whether the provided data for which this result was
 obtained were internally inconsistent and could not be
 used in its entirety. For example, for extrusion
 operation, profile loops were degenerate
 or improperly oriented with respect to the extrsuion
 direction.

## Syntax (C#)
```csharp
public bool HasInvalidData { get; }
```

## Remarks
This variable does not capture presence or absence
 of intersections between different profile loops.

