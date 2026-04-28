---
kind: property
id: P:Autodesk.Revit.DB.MEPCurveType.Union
source: html/e74b59ea-3367-c980-030a-831c1733c4e3.htm
---
# Autodesk.Revit.DB.MEPCurveType.Union Property

The default union fitting of the MEP curve type.

## Syntax (C#)
```csharp
public FamilySymbol Union { get; set; }
```

## Remarks
This property is used to retrieve the default union fitting of the MEP curve type,
and can be Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no default value.
Use RoutingPreferenceManager to set this property for PipeType MEPCurves.

