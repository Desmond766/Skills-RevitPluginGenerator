---
kind: property
id: P:Autodesk.Revit.DB.PrintParameters.Zoom
source: html/e99b9873-6f26-f83b-18c3-ee2cea834775.htm
---
# Autodesk.Revit.DB.PrintParameters.Zoom Property

The zoom value to a percentage of the original size.

## Syntax (C#)
```csharp
public int Zoom { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if current ZoomType is not Zoom type.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown if input zoom value less than 1.

