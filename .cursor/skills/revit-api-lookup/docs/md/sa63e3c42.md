---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateHasValueParameterRule(Autodesk.Revit.DB.ElementId)
source: html/f5d6b4ac-1443-ba8e-14ae-a5a71efacec4.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateHasValueParameterRule Method

Creates a filter rule that determines whether an element's parameter has a value.

## Syntax (C#)
```csharp
public static FilterRule CreateHasValueParameterRule(
	ElementId parameter
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - The parameter to be evaluated by the filter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

