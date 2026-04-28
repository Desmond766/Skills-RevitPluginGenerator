---
kind: property
id: P:Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.Height
zh: 高度
source: html/988b3b7b-799d-0a92-cd42-e1a52a64e6a6.htm
---
# Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.Height Property

**中文**: 高度

The height at which the non-continuous rail will be placed.

## Syntax (C#)
```csharp
public double Height { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The height height is not valid for the non-continuous rail.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for height must be no more than 30000 feet in absolute value.

