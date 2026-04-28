---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotEqualsRule(Autodesk.Revit.DB.ElementId,System.String)
source: html/f7618ce2-1213-9024-1bba-397fdf4466ff.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotEqualsRule Method

Creates a filter rule that determines whether strings from the document do not equal a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateNotEqualsRule(
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

