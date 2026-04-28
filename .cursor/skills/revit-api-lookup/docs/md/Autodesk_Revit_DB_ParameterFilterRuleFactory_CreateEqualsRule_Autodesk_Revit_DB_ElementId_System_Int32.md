---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateEqualsRule(Autodesk.Revit.DB.ElementId,System.Int32)
source: html/3a374069-5d74-7af9-4316-8cc6ef232279.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateEqualsRule Method

Creates a filter rule that determines whether integer values
 from the document equal a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateEqualsRule(
	ElementId parameter,
	int value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - An integer-typed parameter used to get values from the document for a given element.
- **value** (`System.Int32`) - The user-supplied value against which values from the document will be compared.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

