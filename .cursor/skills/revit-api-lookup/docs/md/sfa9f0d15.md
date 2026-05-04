---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.IExternalService.Execute(Autodesk.Revit.DB.ExternalService.IExternalServer,Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalService.IExternalData)
source: html/c70a5092-dccf-6896-1ec0-15f749e84a58.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalService.Execute Method

Implement this method to execute the given server.

## Syntax (C#)
```csharp
bool Execute(
	IExternalServer server,
	Document document,
	IExternalData data
)
```

## Parameters
- **server** (`Autodesk.Revit.DB.ExternalService.IExternalServer`) - An instance of a server that is to be executed.
- **document** (`Autodesk.Revit.DB.Document`) - The associated document. It may be NULL if the service is not being executed
 in a document.
- **data** (`Autodesk.Revit.DB.ExternalService.IExternalData`) - The associated service data.

## Returns
True indicates a successful execution of the call. False indicates a failure.
If a multi-server service returns false from the call, the service manager
 will stop the execution loop and marks the service execution as unsuccessful.

## Remarks
It is completely upon the service to decide what the communication with the server should be like,
 for it is the service provider who also defines what the server's interface looks like.
 It could be as simple as calling one method (e.g. Execute, Run, Calculate, etc.) or it could be
 a set of inquiries and executing calls to the server.
The framework invokes this method when the service is requested to be executed.
 The framework first checks what the applicable server (or servers, in a multi-server
 service) is and then it calls this method with that server as an argument.

