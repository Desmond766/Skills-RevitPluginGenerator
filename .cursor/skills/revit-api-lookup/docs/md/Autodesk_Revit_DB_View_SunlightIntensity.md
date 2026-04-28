---
kind: property
id: P:Autodesk.Revit.DB.View.SunlightIntensity
zh: 视图
source: html/f9059214-07df-c0c3-37e9-fd30eb52098b.htm
---
# Autodesk.Revit.DB.View.SunlightIntensity Property

**中文**: 视图

The intensity of the simulated (directional) sunlight. 0 = no directional light; maximum value is 100.

## Syntax (C#)
```csharp
public int SunlightIntensity { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value is invalid. The valid range is 0 through 100
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This view does not contain display-related properties.

