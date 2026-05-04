---
kind: method
id: M:Autodesk.Revit.DB.RoutingPreferenceRule.AddCriterion(Autodesk.Revit.DB.RoutingCriterionBase)
source: html/09054272-0631-9169-cc6f-c50fa8254da3.htm
---
# Autodesk.Revit.DB.RoutingPreferenceRule.AddCriterion Method

Adds a new routing criterion.

## Syntax (C#)
```csharp
public void AddCriterion(
	RoutingCriterionBase myCriterion
)
```

## Parameters
- **myCriterion** (`Autodesk.Revit.DB.RoutingCriterionBase`) - The criterion to add.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

