---
kind: property
id: P:Autodesk.Revit.DB.GlobalParameter.IsDrivenByFormula
source: html/ee9c7baa-47b9-f84d-c2e2-103711fbb756.htm
---
# Autodesk.Revit.DB.GlobalParameter.IsDrivenByFormula Property

Indicates whether this parameter is driven by a formula or not.

## Syntax (C#)
```csharp
public bool IsDrivenByFormula { get; }
```

## Remarks
Note that the value of this property is always the opposite of the
 IsDrivenByDimension property. It is so because a parameter of which
 value is evaluated by a formula cannot be driven by a dimension, and vice versa.

