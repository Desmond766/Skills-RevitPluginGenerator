---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarCurvesData.SetDistributionPath(System.Collections.Generic.IList{Autodesk.Revit.DB.Curve})
source: html/7d542d46-cedc-9a45-bb83-47be487640cf.htm
---
# Autodesk.Revit.DB.Structure.RebarCurvesData.SetDistributionPath Method

Sets a new distribution path to be applied to the rebar. This information is set to the rebar after the API execution is finished successfully.

## Syntax (C#)
```csharp
public void SetDistributionPath(
	IList<Curve> path
)
```

## Parameters
- **path** (`System.Collections.Generic.IList < Curve >`) - Input curves that describe the new path.

## Remarks
For a free form rebar set the distance between two consecutive bars may be different if it is calculated between different points on bars.
 The distribution path is an array of curves with the property that based on these curves the set was calculated to respect the layout rule and number of bars or spacing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

