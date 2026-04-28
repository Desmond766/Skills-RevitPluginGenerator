---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.MEPHiddenLineSettings.LineStyle
source: html/2c028b70-ea27-ff38-0788-f2c4dd211bd5.htm
---
# Autodesk.Revit.DB.Mechanical.MEPHiddenLineSettings.LineStyle Property

The line style that determines how the lines of a hidden segment display at the point where the segments cross.

## Syntax (C#)
```csharp
public ElementId LineStyle { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The line style is invalid for hidden line display.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

