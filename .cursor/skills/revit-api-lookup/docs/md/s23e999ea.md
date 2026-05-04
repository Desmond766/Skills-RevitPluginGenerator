---
kind: property
id: P:Autodesk.Revit.DB.DividedPath.MinimumDistance
source: html/9969464f-12ed-84c1-9519-93427424db74.htm
---
# Autodesk.Revit.DB.DividedPath.MinimumDistance Property

The minimum distance is used when the layout is set to 'MinimumSpacing'.
 When that layout rule is used the distance between points will not fall below this value.
 The measurement type determines how the distance is measured.

## Syntax (C#)
```csharp
public double MinimumDistance { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The minimumDistance is too small.

