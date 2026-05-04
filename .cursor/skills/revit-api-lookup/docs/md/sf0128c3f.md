---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateContainsRule(Autodesk.Revit.DB.ElementId,System.String,System.Boolean)
source: html/4234db43-f901-1ad6-c89d-9f2f1bae8717.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateContainsRule Method

Creates a filter rule that determines whether strings from the document contain
 a certain string value.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2023 and may be removed in a future version of Revit. Please use the constructor without the `caseSensitive` argument instead.")]
public static FilterRule CreateContainsRule(
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

