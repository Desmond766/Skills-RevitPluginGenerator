---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.GetParameters
source: html/86e30f63-4894-aed9-c6df-0074cdfa89a7.htm
---
# Autodesk.Revit.DB.FamilyManager.GetParameters Method

Gets the parameters associated to family types in order.

## Syntax (C#)
```csharp
public IList<FamilyParameter> GetParameters()
```

## Returns
A collection containing all family parameters.

## Remarks
The parameters are family built-in parameters, category built-in parameters 
and shared parameters associated to the family types. The collection consists of both visible and invisible parameters associated to the family types. The parameters are returned in the order in which they appear in the Revit UI within a given group; 
however, parameters of different groups may be mixed within this output. Currently the Revit UI order is determined first by group and next by the order of the individual parameters.

