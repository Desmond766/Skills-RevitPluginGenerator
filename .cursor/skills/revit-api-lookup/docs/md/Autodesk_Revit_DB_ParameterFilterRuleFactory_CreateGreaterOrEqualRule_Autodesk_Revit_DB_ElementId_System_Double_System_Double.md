---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateGreaterOrEqualRule(Autodesk.Revit.DB.ElementId,System.Double,System.Double)
source: html/3be5900e-4b7b-7197-8a7e-664b7ecc15e5.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateGreaterOrEqualRule Method

Creates a filter rule that determines whether double-precision values
 from the document are greater than or equal to a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateGreaterOrEqualRule(
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

