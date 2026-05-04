---
kind: property
id: P:Autodesk.Revit.DB.MEPCurve.MEPSystem
zh: 系统
source: html/ad663cce-bb05-70bf-33f5-b3d32f9e9b62.htm
---
# Autodesk.Revit.DB.MEPCurve.MEPSystem Property

**中文**: 系统

The system of the MEP curve.

## Syntax (C#)
```csharp
public MEPSystem MEPSystem { get; }
```

## Remarks
Returns the system of this MEP curve.
If the curve does not belong to any systems, the value will be Nothing nullptr a null reference ( Nothing in Visual Basic) .
If the curve belongs to more than one system, the first available value is returned.

