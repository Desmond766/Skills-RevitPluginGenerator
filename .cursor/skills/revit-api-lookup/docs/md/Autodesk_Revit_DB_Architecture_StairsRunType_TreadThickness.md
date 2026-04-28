---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRunType.TreadThickness
source: html/0c6c2238-aba9-0056-4f1f-33793c18b012.htm
---
# Autodesk.Revit.DB.Architecture.StairsRunType.TreadThickness Property

The thickness of the treads.

## Syntax (C#)
```csharp
public double TreadThickness { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for thickness must be greater than 0 and no more than 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The run type has no tread so the data being set is not applicable.

