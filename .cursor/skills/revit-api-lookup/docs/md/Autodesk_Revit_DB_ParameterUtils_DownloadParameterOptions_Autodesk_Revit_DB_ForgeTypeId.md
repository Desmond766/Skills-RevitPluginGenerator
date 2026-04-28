---
kind: method
id: M:Autodesk.Revit.DB.ParameterUtils.DownloadParameterOptions(Autodesk.Revit.DB.ForgeTypeId)
source: html/fd6683df-c93e-eabe-3f6c-dffe61b5cef9.htm
---
# Autodesk.Revit.DB.ParameterUtils.DownloadParameterOptions Method

Retrieves settings associated with the given parameter from the Parameters Service.

## Syntax (C#)
```csharp
public static ParameterDownloadOptions DownloadParameterOptions(
	ForgeTypeId parameterTypeId
)
```

## Parameters
- **parameterTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Parameter identifier.

## Returns
Settings associated with a parameter.

## Remarks
The settings associated with a parameter definition are accessible only to an authorized user.
 To retrieve them, the user must be signed in.

## Exceptions
- **Autodesk.Revit.Exceptions.AccessDeniedException** - Thrown when the user is not authorized to access the requested information.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the given parameter identifier is empty.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **[!:Autodesk::Revit::Exceptions::NetworkCommunicationError]** - Thrown when communication with the Parameters Service is unsuccessful.
- **Autodesk.Revit.Exceptions.ResourceNotFoundException** - Thrown when the requested parameter is not found.
- **Autodesk.Revit.Exceptions.ServerInternalException** - Thrown when the Parameters Service reports an internal error.
- **Autodesk.Revit.Exceptions.UnauthenticatedException** - Thrown when the user is not signed in.

