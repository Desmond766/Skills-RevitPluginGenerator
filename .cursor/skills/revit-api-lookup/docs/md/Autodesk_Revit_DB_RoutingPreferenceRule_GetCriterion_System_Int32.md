---
kind: method
id: M:Autodesk.Revit.DB.RoutingPreferenceRule.GetCriterion(System.Int32)
source: html/e682cffb-e451-b662-ab7f-532d2af3b25a.htm
---
# Autodesk.Revit.DB.RoutingPreferenceRule.GetCriterion Method

Gets the specified criteria.

## Syntax (C#)
```csharp
public RoutingCriterionBase GetCriterion(
	int index
)
```

## Parameters
- **index** (`System.Int32`)

## Returns
The criterion at the specified zero-based index position.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is not a valid zero-based index.
 -or-
 Thrown if the index is out of bounds.

