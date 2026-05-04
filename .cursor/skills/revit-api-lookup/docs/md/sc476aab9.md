---
kind: property
id: P:Autodesk.Revit.DB.MEPCurveType.Tee
zh: 三通
source: html/bd5c961c-3e70-0727-e12c-6fef6a4c1ffa.htm
---
# Autodesk.Revit.DB.MEPCurveType.Tee Property

**中文**: 三通

The default tee fitting of the MEP curve type.

## Syntax (C#)
```csharp
public FamilySymbol Tee { get; set; }
```

## Remarks
This property is used to retrieve the default tee fitting of the MEP curve type,
and can be Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no default value. 
Use RoutingPreferenceManager to set this property for PipeType MEPCurves.

