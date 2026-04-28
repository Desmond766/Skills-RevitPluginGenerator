---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateHasNoValueParameterRule(Autodesk.Revit.DB.ElementId)
source: html/a21791b5-ee59-0a42-6b8d-8354c7748f32.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateHasNoValueParameterRule Method

Creates a filter rule that determines whether an element's parameter does not have a value.

## Syntax (C#)
```csharp
public static FilterRule CreateHasNoValueParameterRule(
	ElementId parameter
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - The parameter to be evaluated by the filter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

