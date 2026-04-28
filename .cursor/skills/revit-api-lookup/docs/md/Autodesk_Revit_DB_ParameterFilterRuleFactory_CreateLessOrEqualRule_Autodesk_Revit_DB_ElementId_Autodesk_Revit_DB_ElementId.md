---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessOrEqualRule(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/487472a6-b353-73b5-97d5-b72aae52af26.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateLessOrEqualRule Method

Creates a filter rule that determines whether ElementId values
 from the document are less than or equal to a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateLessOrEqualRule(
	ElementId parameter,
	ElementId value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - An ElementId-typed parameter used to get values from the document for a given element.
- **value** (`Autodesk.Revit.DB.ElementId`) - The user-supplied value against which values from the document will be compared.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

