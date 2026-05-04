---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateEqualsRule(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/13332eda-1822-237d-51a6-d09df09b5234.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateEqualsRule Method

Creates a filter rule that determines whether ElementId values
 from the document equal a certain value.

## Syntax (C#)
```csharp
public static FilterRule CreateEqualsRule(
	ElementId parameter,
	ElementId value
)
```

## Parameters
- **parameter** (`Autodesk.Revit.DB.ElementId`) - An ElementId-typed parameter used to get values from the document for a given element.
- **value** (`Autodesk.Revit.DB.ElementId`) - The user-supplied value against which values from the document will be compared.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

