---
kind: property
id: P:Autodesk.Revit.DB.Architecture.Stairs.ActualRiserHeight
zh: 楼梯
source: html/d3e335fe-ab3e-118b-156a-db30067ad523.htm
---
# Autodesk.Revit.DB.Architecture.Stairs.ActualRiserHeight Property

**中文**: 楼梯

The actual height of the stairs risers in the stairs.

## Syntax (C#)
```csharp
public double ActualRiserHeight { get; }
```

## Remarks
The stairs height is determined by its base and top elevation. So, the actual riser height = stairs height / desired riser number.

