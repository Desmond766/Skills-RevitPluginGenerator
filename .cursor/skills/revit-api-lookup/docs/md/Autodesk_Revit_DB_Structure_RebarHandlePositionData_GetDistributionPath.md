---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHandlePositionData.GetDistributionPath
source: html/c09f23dd-cb6f-e2b4-b63e-1620d65cb3c5.htm
---
# Autodesk.Revit.DB.Structure.RebarHandlePositionData.GetDistributionPath Method

Gets the distribution path currently stored in the rebar.

## Syntax (C#)
```csharp
public IList<Curve> GetDistributionPath()
```

## Returns
Returns array of curves that represent the distribution path.

## Remarks
For a free form rebar set the distance between two consecutive bars may be different if it is calculated between different points on bars.
 The distribution path is an array of curves with the property that based on these curves the set was calculated to respect the layout rule and number of bars or spacing.

