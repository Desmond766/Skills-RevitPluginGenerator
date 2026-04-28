---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessRule(Autodesk.Revit.DB.ElementId,System.Int32)
source: html/156dde69-2526-3496-fcc3-1677eb7a1292.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessRule Method

Creates a filter rule that determines whether integer values
 from the document are less than a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateLessRule(
	ElementId parameter,
	int value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - An integer-typed parameter used to get values from the document for a given element.
- **value** (`System.Int32`) - The user-supplied value against which values from the document will be compared.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

