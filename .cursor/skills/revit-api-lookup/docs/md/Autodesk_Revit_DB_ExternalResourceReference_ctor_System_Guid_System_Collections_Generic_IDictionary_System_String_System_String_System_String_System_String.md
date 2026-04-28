---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceReference.#ctor(System.Guid,System.Collections.Generic.IDictionary{System.String,System.String},System.String,System.String)
source: html/583b476f-68a7-2671-d5f6-0b38834bb39a.htm
---
# Autodesk.Revit.DB.ExternalResourceReference.#ctor Method

Creates a new ExternalResourceReference from the given data.

## Syntax (C#)
```csharp
public ExternalResourceReference(
	Guid serverId,
	IDictionary<string, string> referenceInformation,
	string version,
	string inSessionPath
)
```

## Parameters
- **serverId** (`System.Guid`) - The id of the server associated with this
 ExternalResourceReference. The server must implement
 IExternalResourceServer.
- **referenceInformation** (`System.Collections.Generic.IDictionary < String , String >`) - The (String, String) map containing reference or lookup information that will
 be stored in Revit.
- **version** (`System.String`) - The version of the external data.
- **inSessionPath** (`System.String`) - The path that identifies a resource in server. ExternalResourceServer must provide this path which should not contain the server name.
 Revit internally will construct and store the full display path which includes the server name plus this path at the time a resource
 is loaded into the model for use if the server is missing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The file is not allowed to access.

