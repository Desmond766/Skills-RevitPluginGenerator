---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.GetSpatialElementCalculationPoint
zh: 族实例
source: html/433caf59-49b1-97df-38ac-8f01a620bef5.htm
---
# Autodesk.Revit.DB.FamilyInstance.GetSpatialElementCalculationPoint Method

**中文**: 族实例

Gets the location of the calculation point for this instance.

## Syntax (C#)
```csharp
public XYZ GetSpatialElementCalculationPoint()
```

## Returns
A 3d point.

## Remarks
See HasSpatialElementCalculationPoint for reference.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if this instance does not have a single calculation point.

