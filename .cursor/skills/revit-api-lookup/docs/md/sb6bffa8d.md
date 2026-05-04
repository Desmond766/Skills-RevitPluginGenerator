---
kind: type
id: T:Autodesk.Revit.DB.SpatialElementCalculationLocation
source: html/f4fed5e0-0964-a973-c8f5-7beb046a2849.htm
---
# Autodesk.Revit.DB.SpatialElementCalculationLocation

The Spatial Element Calculation Location is used to specify the room/space where an
 element should be considered as placed.

## Syntax (C#)
```csharp
public class SpatialElementCalculationLocation : Element
```

## Remarks
It currently has two types of calculation location:
 SpatialElementCalculationPoint and SpatialElementFromToCalculationPoints
 A user can turn on the Spatial Element Calculation Location in the family editor
 by setting the family's ROOM_CALCULATION_POINT parameter.
 A user can move the location of the Spatial Element Calculation Location in the family editor.
 A user can visually verify the location of the Spatial Element Calculation Point by
 selecting the fixture in the project.

