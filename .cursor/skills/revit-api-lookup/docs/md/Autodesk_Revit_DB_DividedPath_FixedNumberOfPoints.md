---
kind: property
id: P:Autodesk.Revit.DB.DividedPath.FixedNumberOfPoints
source: html/f62adb43-3e06-56b9-f86d-fcfc59e21f3c.htm
---
# Autodesk.Revit.DB.DividedPath.FixedNumberOfPoints Property

The number of points used when the layout is set to 'FixedNumber'.

## Syntax (C#)
```csharp
public int FixedNumberOfPoints { get; set; }
```

## Remarks
To get the actual number of point use GetNumberOfPoints().

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: fixedNumberOfPoints must be at least 2 and at most 200.

