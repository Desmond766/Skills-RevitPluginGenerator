---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.GetWorksharingCentralGUID(Autodesk.Revit.DB.ServerPath)
source: html/12bbfa37-ca73-0718-d75d-a7da1ecd4205.htm
---
# Autodesk.Revit.ApplicationServices.Application.GetWorksharingCentralGUID Method

Gets the worksharing central GUID of the given server-based model.

## Syntax (C#)
```csharp
public Guid GetWorksharingCentralGUID(
	ServerPath serverModelPath
)
```

## Parameters
- **serverModelPath** (`Autodesk.Revit.DB.ServerPath`) - The server-based model path.

## Returns
The worksharing central GUID.

## Remarks
The given server-based model saved in a release prior to Revit 2013 did not have this GUID.
 Only the given server-based model saved in Revit 2013 or later will be able to provide this value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CentralModelException** - The central model is missing.
 -or-
 An internal error happened on the central model, please contact the server administrator.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - Thrown when the given model is not created in Revit 2013 or later release.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be accessed
 because of a network communication error.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - An internal error happened on the server, please contact the server administrator.

