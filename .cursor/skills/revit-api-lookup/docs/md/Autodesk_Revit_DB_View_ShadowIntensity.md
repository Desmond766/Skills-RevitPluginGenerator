---
kind: property
id: P:Autodesk.Revit.DB.View.ShadowIntensity
zh: 视图
source: html/fdb46c20-37e8-8483-730c-f169d0aca35c.htm
---
# Autodesk.Revit.DB.View.ShadowIntensity Property

**中文**: 视图

The intesity of cast shadows - 0 = no shadows, 100 = black.

## Syntax (C#)
```csharp
public int ShadowIntensity { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value is invalid. The valid range is 0 through 100
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This view does not contain display-related properties.

