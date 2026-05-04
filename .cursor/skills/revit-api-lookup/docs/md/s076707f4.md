---
kind: property
id: P:Autodesk.Revit.DB.ViewDisplayModel.Transparency
source: html/cde74682-80ea-ce09-ea07-1ef1d01565ab.htm
---
# Autodesk.Revit.DB.ViewDisplayModel.Transparency Property

The percentage (0..100) of surface transparency
 0 means the surfaces are opaque, 100 means they are fully transparent

## Syntax (C#)
```csharp
public int Transparency { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value is invalid. The valid range is 0 through 100

