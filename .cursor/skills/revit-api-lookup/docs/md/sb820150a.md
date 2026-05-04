---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateBeginsWithRule(Autodesk.Revit.DB.ElementId,System.String,System.Boolean)
source: html/7c5214d7-fc2e-6aae-846c-4f87a0e9bdc4.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateBeginsWithRule Method

Creates a filter rule that determines whether strings from the document
 begin with a certain string value.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2023 and may be removed in a future version of Revit. Please use the constructor without the `caseSensitive` argument instead.")]
public static FilterRule CreateBeginsWithRule(
	ElementId parameter,
	string value,
	bool caseSensitive
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - A string-typed parameter used to get values from the document for a given element.
- **value** (`System.String`) - The user-supplied string value for which values from the document will be searched.
- **caseSensitive** (`System.Boolean`) - If true, the string comparison will be case-sensitive.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

