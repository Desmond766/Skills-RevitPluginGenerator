---
kind: property
id: P:Autodesk.Revit.DB.GlobalParameter.IsDrivenByDimension
source: html/201f3932-eece-37b0-be27-3e74ce0c3fb9.htm
---
# Autodesk.Revit.DB.GlobalParameter.IsDrivenByDimension Property

Indicates whether this parameter is driven by a dimension or not.

## Syntax (C#)
```csharp
public bool IsDrivenByDimension { get; }
```

## Remarks
Only reporting parameters can be driven by dimensions. Thus, to drive
 a parameter by a dimension, the parameter must first be set as reporting
 before it is used to label the driving dimension. Note that the value of this property is always the opposite of the
 IsDrivenByFormula property. It is so because a parameter of which
 value is evaluated by a formula cannot be driven by a dimension, and vice versa.

