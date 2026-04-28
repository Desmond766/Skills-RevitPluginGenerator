---
kind: method
id: M:Autodesk.Revit.DB.Subelement.SetParameterValue(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ParameterValue)
source: html/b391bde2-d940-c022-8ab0-a86c7a083b64.htm
---
# Autodesk.Revit.DB.Subelement.SetParameterValue Method

Sets a new parameter value of this subelement given a parameter id.

## Syntax (C#)
```csharp
public void SetParameterValue(
	ElementId parameterId,
	ParameterValue pValue
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - Parameter id.
- **pValue** (`Autodesk.Revit.DB.ParameterValue`) - New value for the parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - parameterId does not identify a valid parameter of this subelement.
 -or-
 The parameter parameterId is not modifiable for this subelement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

