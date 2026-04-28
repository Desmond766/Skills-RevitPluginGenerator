---
kind: property
id: P:Autodesk.Revit.DB.MEPCurveType.Transition
source: html/33842660-06e1-ad7f-096f-01b722ad10c1.htm
---
# Autodesk.Revit.DB.MEPCurveType.Transition Property

The default transition fitting of the MEP curve type.

## Syntax (C#)
```csharp
public FamilySymbol Transition { get; set; }
```

## Remarks
This property is used to retrieve the default transition fitting of the MEP curve type,
and can be Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no default value.
Use RoutingPreferenceManager to set this property for PipeType MEPCurves.

