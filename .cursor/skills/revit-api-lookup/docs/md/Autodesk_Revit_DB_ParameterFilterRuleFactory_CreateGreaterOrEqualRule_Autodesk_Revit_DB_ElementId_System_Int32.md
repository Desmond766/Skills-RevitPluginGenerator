---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateGreaterOrEqualRule(Autodesk.Revit.DB.ElementId,System.Int32)
source: html/5bef06b9-9257-9fd6-d6ca-01fc9d0f5f9e.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateGreaterOrEqualRule Method

Creates a filter rule that determines whether integer values
 from the document are greater than or equal to a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateGreaterOrEqualRule(
	ElementId parameter,
	int value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - An integer-typed parameter used to get values from the document for a given element.
- **value** (`System.Int32`) - The user-supplied value against which values from the document will be compared.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

