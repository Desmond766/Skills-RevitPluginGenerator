---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotEqualsRule(Autodesk.Revit.DB.ElementId,System.Int32)
source: html/09da6f75-c1b4-bf2a-4dee-cd7dcb9dde6f.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotEqualsRule Method

Creates a filter rule that determines whether integer values
 from the document do not equal a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateNotEqualsRule(
	ElementId parameter,
	int value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - An integer-typed parameter used to get values from the document for a given element.
- **value** (`System.Int32`) - The user-supplied value against which values from the document will be compared.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

