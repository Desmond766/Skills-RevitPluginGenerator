---
kind: property
id: P:Autodesk.Revit.DB.ExportLayerInfo.ColorName
source: html/340ddf1d-6b6b-9dc5-b810-adc49fd7e588.htm
---
# Autodesk.Revit.DB.ExportLayerInfo.ColorName Property

The color name stored in value.
 For IFC export, the naming is to match the "colornumber" setting -- really, this stores a string
 that generates the colorNumber (for formats that don't use the color but need a second entry.)

## Syntax (C#)
```csharp
public string ColorName { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

