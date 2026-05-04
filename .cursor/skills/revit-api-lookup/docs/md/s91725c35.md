---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotBeginsWithRule(Autodesk.Revit.DB.ElementId,System.String)
source: html/20b48cfb-0d6a-90c9-6a82-6fe841c5c9cb.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotBeginsWithRule Method

Creates a filter rule that determines whether strings from the document
 do not begin with a certain string value.

## Syntax (C#)
```csharp
public static FilterRule CreateNotBeginsWithRule(
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

