---
kind: property
id: P:Autodesk.Revit.DB.MEPCurveType.Cross
source: html/33d098c2-e4bc-410d-75d9-83575e83a622.htm
---
# Autodesk.Revit.DB.MEPCurveType.Cross Property

The default cross fitting of the MEP curve type.

## Syntax (C#)
```csharp
public FamilySymbol Cross { get; set; }
```

## Remarks
This property is used to retrieve the default cross fitting of the MEP curve type,
and can be Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no default value.
Use RoutingPreferenceManager to set this property for PipeType MEPCurves.

