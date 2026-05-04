---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateEqualsRule(Autodesk.Revit.DB.ElementId,System.String,System.Boolean)
source: html/2a4943e9-4efe-7b79-b1ea-8b85c253001d.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateEqualsRule Method

Creates a filter rule that determines whether strings from the document equal a certain value.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2023 and may be removed in a future version of Revit. Please use the constructor without the `caseSensitive` argument instead.")]
public static FilterRule CreateEqualsRule(
	ElementId parameter,
	string value,
	bool caseSensitive
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - A string-typed parameter used to get values from the document for a given element.
- **value** (`System.String`) - The user-supplied string value against which values from the document will be compared.
- **caseSensitive** (`System.Boolean`) - If true, the string comparison will be case-sensitive.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

