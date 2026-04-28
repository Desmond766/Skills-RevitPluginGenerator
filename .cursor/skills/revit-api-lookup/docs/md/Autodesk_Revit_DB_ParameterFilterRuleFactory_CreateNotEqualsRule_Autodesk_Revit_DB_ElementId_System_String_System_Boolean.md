---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotEqualsRule(Autodesk.Revit.DB.ElementId,System.String,System.Boolean)
source: html/714e6b6e-354f-64ce-7afc-4e272f8cc280.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotEqualsRule Method

Creates a filter rule that determines whether strings from the document do not equal a certain value.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2023 and may be removed in a future version of Revit. Please use the constructor without the `caseSensitive` argument instead.")]
public static FilterRule CreateNotEqualsRule(
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

