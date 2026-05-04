---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterElement.GetElementFilterParameters
source: html/132d12c4-20b4-0b81-7c06-e5ad6f3f903f.htm
---
# Autodesk.Revit.DB.ParameterFilterElement.GetElementFilterParameters Method

Retrieves a list of the parameters associated with each rule in the filter.

## Syntax (C#)
```csharp
public ISet<ElementId> GetElementFilterParameters()
```

## Returns
A set of parameter identifiers.

## Remarks
This function returns only parameters used by this ParameterFilterElement that are common
 to all categories specified in this ParameterFilterElement.
 The ElementFilter may also contain parameters specific to one of the categories
 and not necessarily common to all categories specified in this ParameterFilterElement.
 To get those parameters, use ParameterFilterElement.GetElementFilterParametersForCategory().

