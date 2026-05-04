---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessRule(Autodesk.Revit.DB.ElementId,System.String,System.Boolean)
source: html/94bef079-5776-9c1f-d78e-04c0963e0599.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessRule Method

Creates a filter rule that determines whether strings from the document
 are less than a certain value.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2023 and may be removed in a future version of Revit. Please use the constructor without the `caseSensitive` argument instead.")]
public static FilterRule CreateLessRule(
	ElementId parameter,
	string value,
	bool caseSensitive
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - A string-typed parameter used to get values from the document for a given element.
- **value** (`System.String`) - The user-supplied string value against which values from the document will be compared.
- **caseSensitive** (`System.Boolean`) - If true, the string comparison will be case-sensitive.

## Remarks
For strings, a value is "less" than another if it would appear before
 the other in an alphabetically-sorted list.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

