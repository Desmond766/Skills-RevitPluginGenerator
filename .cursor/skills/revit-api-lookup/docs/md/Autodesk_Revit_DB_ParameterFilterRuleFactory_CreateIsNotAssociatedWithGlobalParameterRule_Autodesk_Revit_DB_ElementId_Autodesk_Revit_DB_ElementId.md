---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateIsNotAssociatedWithGlobalParameterRule(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/600c0aa7-f3ea-8a44-5ae8-f2706deaf240.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateIsNotAssociatedWithGlobalParameterRule Method

Creates a filter rule that determines whether a parameter is not associated
 with a certain global parameter.

## Syntax (C#)
```csharp
public static FilterRule CreateIsNotAssociatedWithGlobalParameterRule(
	ElementId parameter,
	ElementId value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - A parameter that can be associated with an existing global parameter of a compatible type.
- **value** (`Autodesk.Revit.DB.ElementId`) - The global parameter used to test the association.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

