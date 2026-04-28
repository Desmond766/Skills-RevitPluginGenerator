---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateBeginsWithRule(Autodesk.Revit.DB.ElementId,System.String)
source: html/21ed4118-6602-68d0-252b-7dd58ee88b57.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateBeginsWithRule Method

Creates a filter rule that determines whether strings from the document
 begin with a certain string value.

## Syntax (C#)
```csharp
public static FilterRule CreateBeginsWithRule(
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

