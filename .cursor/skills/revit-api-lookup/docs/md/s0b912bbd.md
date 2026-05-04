---
kind: property
id: P:Autodesk.Revit.DB.Architecture.Stairs.ActualTreadDepth
zh: 楼梯
source: html/a29b78ff-5359-ff5f-c742-889e8f50eaa8.htm
---
# Autodesk.Revit.DB.Architecture.Stairs.ActualTreadDepth Property

**中文**: 楼梯

The actual depth of the stairs treads in the stairs, actual tread depth is equal to minimum tread depth by default.

## Syntax (C#)
```csharp
public double ActualTreadDepth { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for actualTreadDepth must be greater than 0 and no more than 30000 feet.

