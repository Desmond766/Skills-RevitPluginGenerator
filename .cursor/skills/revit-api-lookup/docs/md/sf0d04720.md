---
kind: property
id: P:Autodesk.Revit.DB.Grid.IsCurved
zh: 轴网
source: html/016bc6a4-212e-adf1-a6ce-a272568596d9.htm
---
# Autodesk.Revit.DB.Grid.IsCurved Property

**中文**: 轴网

Identifies if the grid line is curved or straight.

## Syntax (C#)
```csharp
public bool IsCurved { get; }
```

## Remarks
A value of True is returned if the grid line is an arc or False if the grid line is
 straight. Use the Curve property to retrieve an object that represents the geometry of the grid
 line.

