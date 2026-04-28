---
kind: method
id: M:Autodesk.Revit.DB.MEPFamilyConnectorInfo.GetConnectorParameterValue(Autodesk.Revit.DB.ElementId)
source: html/a46564d4-0e40-2a83-7c57-9560e9876db7.htm
---
# Autodesk.Revit.DB.MEPFamilyConnectorInfo.GetConnectorParameterValue Method

Gets the parameter value of the specified connector parameter id.

## Syntax (C#)
```csharp
public ParameterValue GetConnectorParameterValue(
	ElementId connectorParameterId
)
```

## Parameters
- **connectorParameterId** (`Autodesk.Revit.DB.ElementId`) - connectorParameterId is defined in the family connector element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

