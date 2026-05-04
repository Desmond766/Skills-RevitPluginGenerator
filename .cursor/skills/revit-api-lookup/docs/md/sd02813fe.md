---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessOrEqualRule(Autodesk.Revit.DB.ElementId,System.Int32)
source: html/134ee688-f359-083f-6314-03e478ea728b.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessOrEqualRule Method

Creates a filter rule that determines whether integer values
 from the document are less than or equal to a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateLessOrEqualRule(
	ElementId parameter,
	int value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - An integer-typed parameter used to get values from the document for a given element.
- **value** (`System.Int32`) - The user-supplied value against which values from the document will be compared.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

