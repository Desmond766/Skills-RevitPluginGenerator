---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessOrEqualRule(Autodesk.Revit.DB.ElementId,System.String)
source: html/ea08d8a6-2959-fad9-70ee-b2feef2835b6.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessOrEqualRule Method

Creates a filter rule that determines whether strings from the document
 are less than or equal to a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateLessOrEqualRule(
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
For strings, a value is "less" than another if it would appear before
 the other in an alphabetically-sorted list.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

