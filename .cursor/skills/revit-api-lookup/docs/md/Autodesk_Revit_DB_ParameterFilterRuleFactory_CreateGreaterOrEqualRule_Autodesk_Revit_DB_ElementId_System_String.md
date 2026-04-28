---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateGreaterOrEqualRule(Autodesk.Revit.DB.ElementId,System.String)
source: html/e7549a8a-72bf-d4ef-e900-18e6b767882a.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateGreaterOrEqualRule Method

Creates a filter rule that determines whether strings from the document
 are greater than or equal to a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateGreaterOrEqualRule(
	ElementId parameter,
	string value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - A string-typed parameter used to get values from the document for a given element.
- **value** (`System.String`) - The user-supplied string value against which values from the document will be compared.

## Returns
Created filter rule object.

## Remarks
For strings, a value is "greater" than another if it would appear after
 the other in an alphabetically-sorted list.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

