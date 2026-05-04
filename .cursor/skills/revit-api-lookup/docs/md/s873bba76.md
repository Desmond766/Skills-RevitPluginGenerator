---
kind: method
id: M:Autodesk.Revit.DB.ParameterUtils.DownloadCompanyName(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ForgeTypeId)
source: html/a7c212e1-43a1-8bc4-f9be-0dcbf56b27c5.htm
---
# Autodesk.Revit.DB.ParameterUtils.DownloadCompanyName Method

Downloads the name of the given parameter's owning account and records it in the given document. If the owning
 account's name is already recorded in the given document, this method returns the name without downloading it
 again.

## Syntax (C#)
```csharp
public static string DownloadCompanyName(
	Document document,
	ForgeTypeId parameterTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document in which to record the name of the parameter's owning account.
- **parameterTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Parameter identifier.

## Returns
Name of the owning account.

## Remarks
In Revit, the account name appears in the parameter tooltip if available.

## Exceptions
- **Autodesk.Revit.Exceptions.AccessDeniedException** - Thrown when the user is not authorized to access the requested information.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the parameter identifier does not include an account identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **[!:Autodesk::Revit::Exceptions::NetworkCommunicationError]** - Thrown when communication with the remote service is unsuccessful.
- **Autodesk.Revit.Exceptions.ResourceNotFoundException** - Thrown when the requested information is not found.
- **Autodesk.Revit.Exceptions.ServerInternalException** - Thrown when the remote service reports an internal error.
- **Autodesk.Revit.Exceptions.UnauthenticatedException** - Thrown when the user is not signed in.

