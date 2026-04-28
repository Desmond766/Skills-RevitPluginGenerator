---
kind: property
id: P:Autodesk.Revit.DB.Grid.Curve
zh: 曲线
source: html/0fce3154-595f-62f5-65d7-e5065c1234a0.htm
---
# Autodesk.Revit.DB.Grid.Curve Property

**中文**: 曲线

Retrieves an object that represents the geometry of the grid line.

## Syntax (C#)
```csharp
public Curve Curve { get; }
```

## Remarks
The geometry can either be an arc or a curve. The IsCurved property can be used to determine
this.

