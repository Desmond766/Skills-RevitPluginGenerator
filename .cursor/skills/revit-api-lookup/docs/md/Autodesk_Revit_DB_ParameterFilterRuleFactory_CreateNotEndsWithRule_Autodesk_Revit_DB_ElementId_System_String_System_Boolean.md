---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotEndsWithRule(Autodesk.Revit.DB.ElementId,System.String,System.Boolean)
source: html/92c8899d-42b6-92fa-f7d3-d0ede2dedccd.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotEndsWithRule Method

Creates a filter rule that determines whether strings from the document
 do not end with a certain string value.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2023 and may be removed in a future version of Revit. Please use the constructor without the `caseSensitive` argument instead.")]
public static FilterRule CreateNotEndsWithRule(
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

