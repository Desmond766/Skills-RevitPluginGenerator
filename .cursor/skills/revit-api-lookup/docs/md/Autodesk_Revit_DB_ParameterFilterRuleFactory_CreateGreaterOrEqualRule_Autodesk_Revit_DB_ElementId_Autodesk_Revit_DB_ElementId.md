---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateGreaterOrEqualRule(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/88ab89de-0fbc-9750-cbfe-cacd637b3f00.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateGreaterOrEqualRule Method

Creates a filter rule that determines whether ElementId values
 from the document are greater than or equal to a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateGreaterOrEqualRule(
	ElementId parameter,
	ElementId value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - An ElementId-typed parameter used to get values from the document for a given element.
- **value** (`Autodesk.Revit.DB.ElementId`) - The user-supplied value against which values from the document will be compared.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

