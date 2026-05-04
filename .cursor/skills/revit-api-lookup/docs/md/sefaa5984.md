---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsLandingType.Thickness
zh: 厚度
source: html/4b4ea1f4-1887-21e9-2f76-8a184c9e7d93.htm
---
# Autodesk.Revit.DB.Architecture.StairsLandingType.Thickness Property

**中文**: 厚度

Thickness of the stairs landing.

## Syntax (C#)
```csharp
public double Thickness { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for thickness must be greater than 0 and no more than 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The landing type doesn't have monolithic support.

