---
kind: property
id: P:Autodesk.Revit.DB.Structure.PointLoad.Point
zh: 点
source: html/65e1dc52-453d-4eda-54a2-3c8a4c100dac.htm
---
# Autodesk.Revit.DB.Structure.PointLoad.Point Property

**中文**: 点

Returns the position of point load, measured in decimal feet.

## Syntax (C#)
```csharp
public XYZ Point { get; set; }
```

## Remarks
Loacation can be set only for hosted loads.
 This method works for loads which are not constrained to their host.
 To determine if load is hosted use IsHosted property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This PointLoad is not a hosted load.
 -or-
 When setting this property: This PointLoad is a constrained load.

