---
kind: property
id: P:Autodesk.Revit.DB.FamilyInstance.HasSpatialElementFromToCalculationPoints
zh: 族实例
source: html/eef2d8ce-6070-d666-b03d-480ef87d04a3.htm
---
# Autodesk.Revit.DB.FamilyInstance.HasSpatialElementFromToCalculationPoints Property

**中文**: 族实例

Identifies if this instance has a pair of SpatialElementCalculationPoints used as the search points for Revit to identify if the instance lies between up to two rooms or spaces.

## Syntax (C#)
```csharp
public bool HasSpatialElementFromToCalculationPoints { get; }
```

## Returns
True if this instance has a pair of SpatialElementCalculationPoints used as the search points, false otherwise.

## Remarks
The points determine which room or space is considered the "from" and which is considered the "to" for a family instance which connects two rooms or spaces, such as a door or window.

