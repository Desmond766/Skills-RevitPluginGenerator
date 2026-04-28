---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessRule(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/ade19090-ae9f-81a3-99ae-123d0155f796.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessRule Method

Creates a filter rule that determines whether ElementId values
 from the document are less than a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateLessRule(
	ElementId parameter,
	ElementId value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - An ElementId-typed parameter used to get values from the document for a given element.
- **value** (`Autodesk.Revit.DB.ElementId`) - The user-supplied value against which values from the document will be compared.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

