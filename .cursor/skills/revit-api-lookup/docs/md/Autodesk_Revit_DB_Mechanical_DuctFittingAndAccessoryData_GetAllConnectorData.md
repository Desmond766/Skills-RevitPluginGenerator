---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.DuctFittingAndAccessoryData.GetAllConnectorData
source: html/6a6fd6cc-325d-4d44-6e08-309cdc81ef42.htm
---
# Autodesk.Revit.DB.Mechanical.DuctFittingAndAccessoryData.GetAllConnectorData Method

Gets the connector data of the pipe fitting or pipe accessory.

## Syntax (C#)
```csharp
public IList<DuctFittingAndAccessoryConnectorData> GetAllConnectorData()
```

## Returns
All connector data.

## Remarks
DuctFittingAndAccessoryConnectorData contains connector data which is needed to calculate coefficient.
 such as width, height, diameter and flow.

