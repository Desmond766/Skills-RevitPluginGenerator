---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipeFittingAndAccessoryData.GetAllConnectorData
source: html/66c865d8-12fe-cc4c-cbdc-674c62d5f528.htm
---
# Autodesk.Revit.DB.Plumbing.PipeFittingAndAccessoryData.GetAllConnectorData Method

Gets the connector data of the pipe fitting or pipe accessory.

## Syntax (C#)
```csharp
public IList<PipeFittingAndAccessoryConnectorData> GetAllConnectorData()
```

## Returns
All connector data.

## Remarks
PipeFittingAndAccessoryConnectorData contains connector data which is needed to calculate coefficient.
 such as width, height, diameter and flow.

