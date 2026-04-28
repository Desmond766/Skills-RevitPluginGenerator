---
kind: property
id: P:Autodesk.Revit.DB.ExternalService.ExternalService.IsSerializable
source: html/11302e75-b2d9-3281-c79d-aa0bf2423588.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalService.IsSerializable Property

Indicates whether executions of the service requires serialization in documents or not.

## Syntax (C#)
```csharp
public bool IsSerializable { get; }
```

## Remarks
When a serializable service is executed in a document, a record about the executed
 server (or servers) is stored in the document's history. This allows active servers
 to be synchronized next time a saved document is opened in Revit.
Executions of a serializable service in a document must happen inside a transaction.

