---
kind: property
id: P:Autodesk.Revit.DB.ColorFillLegend.Origin
zh: 原点
source: html/b0359d5c-a5f2-dfa6-9804-0d63ea15ad2e.htm
---
# Autodesk.Revit.DB.ColorFillLegend.Origin Property

**中文**: 原点

The top left corner of the color fill legend.

## Syntax (C#)
```csharp
public XYZ Origin { get; set; }
```

## Remarks
The origin point must be on the view plane this legend is placed on.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The origin is not on the view plane that this legend is placed on.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

