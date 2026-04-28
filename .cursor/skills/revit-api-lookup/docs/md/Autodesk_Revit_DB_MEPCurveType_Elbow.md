---
kind: property
id: P:Autodesk.Revit.DB.MEPCurveType.Elbow
zh: 管件、弯头、三通
source: html/3eec7500-a2e5-bd1f-2eac-5e2ea6953104.htm
---
# Autodesk.Revit.DB.MEPCurveType.Elbow Property

**中文**: 管件、弯头、三通

The default elbow fitting of the MEP curve type.

## Syntax (C#)
```csharp
public FamilySymbol Elbow { get; set; }
```

## Remarks
This property is used to retrieve the default elbow fitting of the MEP curve type,
and can be Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no default value.
Use RoutingPreferenceManager to set this property for PipeType MEPCurves.

