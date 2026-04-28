---
kind: method
id: M:Autodesk.Revit.DB.Analysis.Polyloop.ComputeArea
source: html/68d3c8af-ee8f-8774-68aa-7618dc6de03e.htm
---
# Autodesk.Revit.DB.Analysis.Polyloop.ComputeArea Method

Gets the area for this polygon.

## Syntax (C#)
```csharp
public double ComputeArea()
```

## Returns
The area for this polygon.

## Remarks
The area of the planar non-self-intersecting polygon computed as:
 A = 1/2 * (X1 Y2) - (X2 Y1) + ... + (Xn Y1) - (X1 Yn)

