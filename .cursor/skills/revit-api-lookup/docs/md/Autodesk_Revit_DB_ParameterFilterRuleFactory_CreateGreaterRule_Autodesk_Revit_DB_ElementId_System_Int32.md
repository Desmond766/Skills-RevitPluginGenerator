---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateGreaterRule(Autodesk.Revit.DB.ElementId,System.Int32)
source: html/86a395f9-c085-a4c3-dd3e-23faa4e7cd3d.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateGreaterRule Method

Creates a filter rule that determines whether integer values
 from the document are greater than a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateGreaterRule(
	ElementId parameter,
	int value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - An integer-typed parameter used to get values from the document for a given element.
- **value** (`System.Int32`) - The user-supplied value against which values from the document will be compared.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

