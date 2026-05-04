---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateEqualsRule(Autodesk.Revit.DB.ElementId,System.String)
source: html/365d4fca-bbb0-c05b-5940-3104982589c8.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateEqualsRule Method

Creates a filter rule that determines whether strings from the document equal a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateEqualsRule(
	ElementId parameter,
	string value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - A string-typed parameter used to get values from the document for a given element.
- **value** (`System.String`) - The user-supplied string value against which values from the document will be compared.

## Returns
Created filter rule object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

