---
kind: property
id: P:Autodesk.Revit.DB.BoundingBoxXYZ.Bounds(System.Int32)
zh: 包围盒
source: html/8ae9bebf-834d-cb1b-fcff-8b1084996ac1.htm
---
# Autodesk.Revit.DB.BoundingBoxXYZ.Bounds Property

**中文**: 包围盒

Indexed access for loops. Use 0 for Min and 1 for Max.

## Syntax (C#)
```csharp
public XYZ this[
	int bound
] { get; set; }
```

## Parameters
- **bound** (`System.Int32`)

## Remarks
The bounds are defined in the coordinate space of the box.

