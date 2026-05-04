---
kind: method
id: M:Autodesk.Revit.DB.Solid.ComputeCentroid
source: html/42d79808-231b-f802-f574-6b799c95b871.htm
---
# Autodesk.Revit.DB.Solid.ComputeCentroid Method

Returns the Centroid of this solid.

## Syntax (C#)
```csharp
public XYZ ComputeCentroid()
```

## Returns
The XYZ point of the Centroid of this solid.

## Remarks
Calculates the centroid of the solid using an approximation, with an accuracy suitable for architectural purposes.
This will correspond only with the center of gravity if the solid represents a homogeneous structure of a single material.

