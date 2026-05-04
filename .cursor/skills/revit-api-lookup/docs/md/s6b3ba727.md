---
kind: property
id: P:Autodesk.Revit.DB.OrdinateDimensionSetting.DimensionLineLength
source: html/90877d1c-da97-731f-ff27-d41fac9cbd29.htm
---
# Autodesk.Revit.DB.OrdinateDimensionSetting.DimensionLineLength Property

Specifies the dimension line segment length. This setting is enabled when Dimension Line Style is Segmented.

## Syntax (C#)
```csharp
public double DimensionLineLength { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for dimensionLineLength must be greater than 0 and no more than 30000 feet.

