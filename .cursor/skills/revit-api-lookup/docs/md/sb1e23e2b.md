---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceLoadData.GetLoadRequestId
source: html/100db979-8bf8-f9a2-fe8d-9db4d8656224.htm
---
# Autodesk.Revit.DB.ExternalResourceLoadData.GetLoadRequestId Method

Returns the load operation GUID.

## Syntax (C#)
```csharp
public Guid GetLoadRequestId()
```

## Returns
The load operation GUID.

## Remarks
This Id uniquely identifies the load request. IExternalResourceServers can use it as a key to store
 and retrieve information (such as errors) that is relevant to a specific load operation.

