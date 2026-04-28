---
kind: property
id: P:Autodesk.Revit.DB.ColorFillLegend.Height
zh: 高度
source: html/7989267f-da55-4f56-2088-6536d68e4c8e.htm
---
# Autodesk.Revit.DB.ColorFillLegend.Height Property

**中文**: 高度

The height of the legend.

## Syntax (C#)
```csharp
public double Height { get; set; }
```

## Remarks
Changing the height may result in a change in the count of columns.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for height must be positive.

