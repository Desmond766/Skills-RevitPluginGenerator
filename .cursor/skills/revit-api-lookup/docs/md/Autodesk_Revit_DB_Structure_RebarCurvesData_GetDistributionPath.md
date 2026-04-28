---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarCurvesData.GetDistributionPath
source: html/5067a5af-283a-032f-1724-b2bf1c8628c9.htm
---
# Autodesk.Revit.DB.Structure.RebarCurvesData.GetDistributionPath Method

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

