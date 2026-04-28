---
kind: method
id: M:Autodesk.Revit.DB.MEPFamilyConnectorInfo.GetAssociateFamilyParameterId(Autodesk.Revit.DB.ElementId)
source: html/0184cc98-e638-a351-8886-4f7ab3f76cd6.htm
---
# Autodesk.Revit.DB.MEPFamilyConnectorInfo.GetAssociateFamilyParameterId Method

Gets the associate family parameter id of the specified connector parameter id.

## Syntax (C#)
```csharp
public ElementId GetAssociateFamilyParameterId(
	ElementId connectorParameterId
)
```

## Parameters
- **connectorParameterId** (`Autodesk.Revit.DB.ElementId`) - connectorParameterId is defined in the family connector element.

## Returns
Returns valid ElementId if the connectorParameterId associates to one family parameter; otherwise returns invalid ElementId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

