---
kind: property
id: P:Autodesk.Revit.DB.MEPCurveType.MultiShapeTransition
source: html/43b3040f-1d0f-a8ee-5fac-bb5380562e45.htm
---
# Autodesk.Revit.DB.MEPCurveType.MultiShapeTransition Property

The default multi shape transition fitting of the MEP curve type.

## Syntax (C#)
```csharp
public FamilySymbol MultiShapeTransition { get; set; }
```

## Remarks
This property is used to retrieve the default multi shape transition fitting of the MEP curve type,
and can be Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no default value.
Use RoutingPreferenceManager to set this property for PipeType MEPCurves.

