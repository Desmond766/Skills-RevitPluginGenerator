---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotEndsWithRule(Autodesk.Revit.DB.ElementId,System.String)
source: html/fcaa12b3-c6d7-b7fa-99ab-fb8b90f311df.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotEndsWithRule Method

Creates a filter rule that determines whether strings from the document
 do not end with a certain string value.

## Syntax (C#)
```csharp
public static FilterRule CreateNotEndsWithRule(
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

