---
kind: property
id: P:Autodesk.Revit.DB.Architecture.Stairs.Height
zh: 高度
source: html/252de077-e133-070a-cb90-7737bf0f445d.htm
---
# Autodesk.Revit.DB.Architecture.Stairs.Height Property

**中文**: 高度

The height of the stair between the base and top levels.

## Syntax (C#)
```csharp
public double Height { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for stairsHeight must be greater than 0 and no more than 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The stairs top level is not "None", so the height cannot be set independently.

