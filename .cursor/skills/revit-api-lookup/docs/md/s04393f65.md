---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotEqualsRule(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/fed5122e-b2d2-bfbb-1ca5-db4e8ae9f7c3.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateNotEqualsRule Method

Creates a filter rule that determines whether ElementId values
 from the document do not equal a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateNotEqualsRule(
	ElementId parameter,
	ElementId value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - An ElementId-typed parameter used to get values from the document for a given element.
- **value** (`Autodesk.Revit.DB.ElementId`) - The user-supplied value against which values from the document will be compared.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

