---
kind: method
id: M:Autodesk.Revit.DB.IExternalResourceServer.IsResourceWellFormed(Autodesk.Revit.DB.ExternalResourceReference)
source: html/87a9e2e8-a675-10a9-b8c5-a3b1e7db2535.htm
---
# Autodesk.Revit.DB.IExternalResourceServer.IsResourceWellFormed Method

Implement this method to check whether the given ExternalResourceReference is formatted
 correctly for this server.

## Syntax (C#)
```csharp
bool IsResourceWellFormed(
	ExternalResourceReference extRef
)
```

## Parameters
- **extRef** (`Autodesk.Revit.DB.ExternalResourceReference`) - The ExternalResourceReference to check.

## Returns
True if the ExternalResourceReference represents a well-formed
 resource. False otherwise.

## Remarks
Different servers will have different requirements. A server which loads references from a website might
 require that the reference map contain a key called "URL"
 and a value that is a valid URL. A server which loads references from a network drive
 might require a key called "Drive" with a value that
 represents a drive name, plus a key called "Path" with
 a value that corresponds to a path relative to the root
 of the drive. This function should not check that the resource exists
 on the server. It should only check that the resource is
 formatted correctly.

