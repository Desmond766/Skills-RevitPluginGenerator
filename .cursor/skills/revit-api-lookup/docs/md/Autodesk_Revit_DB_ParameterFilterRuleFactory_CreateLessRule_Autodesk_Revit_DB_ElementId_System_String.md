---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessRule(Autodesk.Revit.DB.ElementId,System.String)
source: html/038843e0-fdb9-36f4-00b3-776d107f70c1.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessRule Method

Creates a filter rule that determines whether strings from the document
 are less than a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateLessRule(
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

