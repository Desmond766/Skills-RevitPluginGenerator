---
kind: property
id: P:Autodesk.Revit.DB.MEPCurveType.Tap
source: html/2e1d5217-01f2-e1f7-ebab-d3c8d2afa8a6.htm
---
# Autodesk.Revit.DB.MEPCurveType.Tap Property

The default tap fitting of the MEP curve type.

## Syntax (C#)
```csharp
public FamilySymbol Tap { get; set; }
```

## Remarks
This property is used to retrieve the default tap fitting of the MEP curve type,
and can be Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no default value.
Use RoutingPreferenceManager to set this property for PipeType MEPCurves.

