---
kind: property
id: P:Autodesk.Revit.DB.FamilyParameter.IsReporting
source: html/70ebd545-8eb1-4f3b-0381-c28d6b70ca2a.htm
---
# Autodesk.Revit.DB.FamilyParameter.IsReporting Property

Indicates if the parameter is a reporting parameter.

## Syntax (C#)
```csharp
public bool IsReporting { get; }
```

## Remarks
If true, the parameter is a reporting parameter associated to a dimension value,
and cannot be modified. If false, the parameter is a driving parameter and if associated 
to a dimension, can modify the dimension it labels.

