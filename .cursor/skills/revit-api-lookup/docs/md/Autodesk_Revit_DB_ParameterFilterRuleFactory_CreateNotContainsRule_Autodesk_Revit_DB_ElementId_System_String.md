---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotContainsRule(Autodesk.Revit.DB.ElementId,System.String)
source: html/64869b9b-b67c-ed4e-8c5c-b204c936190c.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotContainsRule Method

Creates a filter rule that determines whether strings from the document do not
 contain a certain string value.

## Syntax (C#)
```csharp
public static FilterRule CreateNotContainsRule(
	ElementId parameter,
	string value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - A string-typed parameter used to get values from the document for a given element.
- **value** (`System.String`) - The user-supplied string value for which values from the document will be searched.

## Returns
Created filter rule object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

