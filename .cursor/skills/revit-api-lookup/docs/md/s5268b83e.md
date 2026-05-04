---
kind: method
id: M:Autodesk.Revit.DB.IExternalResourceServer.AreSameResources(System.Collections.Generic.IDictionary{System.String,System.String},System.Collections.Generic.IDictionary{System.String,System.String})
source: html/1c899112-b8e7-bbaf-2385-e77f8afe04f8.htm
---
# Autodesk.Revit.DB.IExternalResourceServer.AreSameResources Method

Implement this method to indicate whether two given resources are the same.

## Syntax (C#)
```csharp
bool AreSameResources(
	IDictionary<string, string> reference1,
	IDictionary<string, string> reference2
)
```

## Parameters
- **reference1** (`System.Collections.Generic.IDictionary < String , String >`)
- **reference2** (`System.Collections.Generic.IDictionary < String , String >`)

## Returns
True if two given resources are the same; otherwise false.

