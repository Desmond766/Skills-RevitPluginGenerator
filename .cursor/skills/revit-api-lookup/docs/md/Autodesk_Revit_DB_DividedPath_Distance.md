---
kind: property
id: P:Autodesk.Revit.DB.DividedPath.Distance
source: html/1ea6b5ba-511c-aefc-8104-cfbfd14c2b6b.htm
---
# Autodesk.Revit.DB.DividedPath.Distance Property

The distance between points that are distributed along the path according to the selected layout.
 When the layout is set to 'FixedDistance' this value can be set to desired distance.
 The measurement type determines how the distance is measured.

## Syntax (C#)
```csharp
public double Distance { get; set; }
```

## Remarks
This does not take into account points obtained by intersections with other elements.
 When the layout is set to 'None' the distance is the value that would be used by the 'FixedDistance' layout.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The distance is too small.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The distance can only be set when the layout of this DividedPath is set to 'FixedDistance' or 'None'.

