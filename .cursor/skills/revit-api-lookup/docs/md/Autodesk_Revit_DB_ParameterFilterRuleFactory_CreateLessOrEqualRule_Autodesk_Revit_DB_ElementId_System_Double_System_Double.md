---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessOrEqualRule(Autodesk.Revit.DB.ElementId,System.Double,System.Double)
source: html/6fc427ee-25ae-2012-b9a0-105ccbcaf343.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessOrEqualRule Method

Creates a filter rule that determines whether double-precision values
 from the document are less than or equal to a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateLessOrEqualRule(
	ElementId parameter,
	double value,
	double epsilon
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - A double-typed parameter used to get values from the document for a given element.
- **value** (`System.Double`) - The user-supplied value against which values from the document will be compared.
- **epsilon** (`System.Double`) - Defines the tolerance within which two values may be considered equal.

## Remarks
Values greater than the user-supplied value but within epsilon 
 are considered equal; therefore, such values satisfy the condition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for value is not finite
 -or-
 The given value for value is not a number
 -or-
 The given value for epsilon is not finite
 -or-
 The given value for epsilon is not a number
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

