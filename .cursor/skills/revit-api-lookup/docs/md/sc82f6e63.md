---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateContainsRule(Autodesk.Revit.DB.ElementId,System.String)
source: html/68f7fb12-b59e-e418-2002-8c52d7143b4f.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateContainsRule Method

Creates a filter rule that determines whether strings from the document contain
 a certain string value.

## Syntax (C#)
```csharp
public static FilterRule CreateContainsRule(
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

