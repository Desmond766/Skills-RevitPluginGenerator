---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.Update
zh: 修改、更改、更新、调整
source: html/738b8438-8952-7af5-86d9-a1d631ec903b.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.Update Method

**中文**: 修改、更改、更新、调整

Updates the path of travel by recalculating the path between the original start and end points.

## Syntax (C#)
```csharp
public PathOfTravelCalculationStatus Update()
```

## Returns
The status result of the recalculation.

## Remarks
If recalculation results in failure, Revit will post a warning.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This functionality is not available in Revit LT.

