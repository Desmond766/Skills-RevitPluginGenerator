---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotContainsRule(Autodesk.Revit.DB.ElementId,System.String,System.Boolean)
source: html/5dd5a295-a283-cda7-7190-70d5cbe1a91c.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotContainsRule Method

Creates a filter rule that determines whether strings from the document do not
 contain a certain string value.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2023 and may be removed in a future version of Revit. Please use the constructor without the `caseSensitive` argument instead.")]
public static FilterRule CreateNotContainsRule(
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

