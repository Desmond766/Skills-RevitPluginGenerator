---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateIsAssociatedWithGlobalParameterRule(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/fa6131e9-7dbe-1c6e-9339-39c6cd92486a.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateIsAssociatedWithGlobalParameterRule Method

Creates a filter rule that determines whether a parameter is associated
 with a certain global parameter.

## Syntax (C#)
```csharp
public static FilterRule CreateIsAssociatedWithGlobalParameterRule(
	ElementId parameter,
	ElementId value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - A parameter that can be associated with an existing global parameter of a compatible type.
- **value** (`Autodesk.Revit.DB.ElementId`) - The global parameter used to test the association.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

