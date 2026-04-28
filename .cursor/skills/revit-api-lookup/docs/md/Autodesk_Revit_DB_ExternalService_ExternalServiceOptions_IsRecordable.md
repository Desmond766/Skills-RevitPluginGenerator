---
kind: property
id: P:Autodesk.Revit.DB.ExternalService.ExternalServiceOptions.IsRecordable
source: html/6e498d20-af67-9292-93db-0b125cb8536c.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServiceOptions.IsRecordable Property

Indicates whether executions of the service is recorded in documents or not.

## Syntax (C#)
```csharp
public bool IsRecordable { get; set; }
```

## Remarks
When a recordable service is executed in a document, a record about the executed
 server (or servers) is stored in the document's history. This allows active servers
 to be synchronized next time a saved document is opened in Revit. Executions of a recordable service in a document must happen inside a transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: A service that doens't support activation should not be recordable.

