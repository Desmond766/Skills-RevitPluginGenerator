---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateEndsWithRule(Autodesk.Revit.DB.ElementId,System.String)
source: html/a1d0b45e-6669-ebe7-a10c-5bc40c7272d2.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateEndsWithRule Method

Creates a filter rule that determines whether strings from the document
 end with a certain string value.

## Syntax (C#)
```csharp
public static FilterRule CreateEndsWithRule(
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

