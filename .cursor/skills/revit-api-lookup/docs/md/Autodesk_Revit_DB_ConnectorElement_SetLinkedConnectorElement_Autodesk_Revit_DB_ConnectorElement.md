---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.SetLinkedConnectorElement(Autodesk.Revit.DB.ConnectorElement)
source: html/2d906fcc-bffc-2217-eae2-fd0c466850ba.htm
---
# Autodesk.Revit.DB.ConnectorElement.SetLinkedConnectorElement Method

Set the linked connector element.

## Syntax (C#)
```csharp
public void SetLinkedConnectorElement(
	ConnectorElement otherConnector
)
```

## Parameters
- **otherConnector** (`Autodesk.Revit.DB.ConnectorElement`) - The connector to link to.

## Remarks
Set the linked connector to Nothing nullptr a null reference ( Nothing in Visual Basic) to remove the link.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The connector being linked to is a different domain than that of the calling connector.
 -or-
 The connector being linked to is the same as the calling connector.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This connector type does not support linked connectors.

