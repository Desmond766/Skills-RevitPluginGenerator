---
kind: method
id: M:Autodesk.Revit.DB.Element.GetOrderedParameters
zh: 构件、图元、元素
source: html/4bf4c0da-f841-0943-f9e0-246a666c1775.htm
---
# Autodesk.Revit.DB.Element.GetOrderedParameters Method

**中文**: 构件、图元、元素

Gets the parameters associated to the element in order.

## Syntax (C#)
```csharp
public IList<Parameter> GetOrderedParameters()
```

## Returns
A collection containing all parameters.

## Remarks
The collection consists of only visible parameters associated to the element; it returns a different list than Element.Parameters. The parameters are returned in the order in which they appear in the Revit UI within a given group; 
however, parameters of different groups may be mixed within this output. Currently the Revit UI order is determined first by group and next by the order of the individual parameters.

