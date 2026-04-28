---
kind: property
id: P:Autodesk.Revit.DB.Architecture.CutMarkType.CutLineDistance
source: html/3f3b60cb-d029-2eb5-b4dd-51795c2a0380.htm
---
# Autodesk.Revit.DB.Architecture.CutMarkType.CutLineDistance Property

The distance between 2 cut lines.

## Syntax (C#)
```csharp
public double CutLineDistance { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for distanceBetweenTwoLines must be greater than 0 and no more than 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The cut mark type is not a double cut line type.

