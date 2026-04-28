---
kind: method
id: M:Autodesk.Revit.DB.Subelement.GetParameterValue(Autodesk.Revit.DB.ElementId)
source: html/c1af0433-3e94-6e40-429b-ad77aaeaff73.htm
---
# Autodesk.Revit.DB.Subelement.GetParameterValue Method

Obtains the current parameter value of this subelement given a parameter id.

## Syntax (C#)
```csharp
public ParameterValue GetParameterValue(
	ElementId parameterId
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - Parameter id.

## Returns
Parameter value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - parameterId does not identify a valid parameter of this subelement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

