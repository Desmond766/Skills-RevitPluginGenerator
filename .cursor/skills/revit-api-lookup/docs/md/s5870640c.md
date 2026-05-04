---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.SingleServerService.GetActiveServerId(Autodesk.Revit.DB.Document)
source: html/db079180-d2a0-dd63-999c-92b995407bbb.htm
---
# Autodesk.Revit.DB.ExternalService.SingleServerService.GetActiveServerId Method

Returns the Id of the server currently associated with the given document for the service.

## Syntax (C#)
```csharp
public Guid GetActiveServerId(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for which the server is being set as active.

## Returns
The Guid of the active server, or an invalid Guid if there is no active server assigned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

