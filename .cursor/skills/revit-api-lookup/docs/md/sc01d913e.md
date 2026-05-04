---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.GetSpatialElementFromToCalculationPoints
zh: 族实例
source: html/21810873-d413-f6e4-ca33-d2ee4e93643e.htm
---
# Autodesk.Revit.DB.FamilyInstance.GetSpatialElementFromToCalculationPoints Method

**中文**: 族实例

Gets the locations for the calculation points for this instance.

## Syntax (C#)
```csharp
public IList<XYZ> GetSpatialElementFromToCalculationPoints()
```

## Returns
A list of 3d points.

## Remarks
For a family instance which connects two rooms or spaces, such as a door or window, the points determine which room or space is considered the "from" and which is considered the "to".

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if this instance does not have from/to calculation points..

