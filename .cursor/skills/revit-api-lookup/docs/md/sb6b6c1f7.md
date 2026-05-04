---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessRule(Autodesk.Revit.DB.ElementId,System.Double,System.Double)
source: html/d64a5bd6-a1e2-4403-76e8-6bbaaab0abb0.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessRule Method

Creates a filter rule that determines whether double-precision values
 from the document are less than a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateLessRule(
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
Values less than the user-supplied value but within epsilon 
 are considered equal, not less.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for value is not finite
 -or-
 The given value for value is not a number
 -or-
 The given value for epsilon is not finite
 -or-
 The given value for epsilon is not a number
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

