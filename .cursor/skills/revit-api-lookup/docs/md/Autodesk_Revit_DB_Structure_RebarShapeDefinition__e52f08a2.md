---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarShapeDefinition
source: html/bb1f59be-c95e-a45b-8d2b-8121df179676.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinition

A class to assist in defining rebar shapes.
 A RebarShape element needs exactly one RebarShapeDefinition.

## Syntax (C#)
```csharp
public class RebarShapeDefinition : IDisposable
```

## Remarks
A RebarShapeDefinition stores a set of Rebar Shape parameters. Each parameter
 may be associated with:
 One or more RebarShapeConstraints; or A formula; or Neither of the above. 
 Each shape instance (Rebar object) will have its own values for these parameters.
 The RebarShapeDefinition also stores a default value for each parameter,
 which is ignored if the parameter is associated with a formula.

