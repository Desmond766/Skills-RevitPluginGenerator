---
kind: method
id: M:Autodesk.Revit.DB.IExternalResourceServer.GetInSessionPath(Autodesk.Revit.DB.ExternalResourceReference,System.String)
source: html/d76436f0-cba3-62b5-ae71-551a69f7d928.htm
---
# Autodesk.Revit.DB.IExternalResourceServer.GetInSessionPath Method

Implement this method to provide the path that should be used for display and browsing to a given ExternalResourceReference
 during this Revit session.

## Syntax (C#)
```csharp
string GetInSessionPath(
	ExternalResourceReference reference,
	string originalDisplayPath
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.ExternalResourceReference`) - The ExternalResourceReference for which Revit is requesting the in session display path.
- **originalDisplayPath** (`System.String`) - The path that was provided for the resource when the resource was originally loaded into the model.

## Returns
The display path that should be used for this resource for this session of Revit.

## Remarks
This method allows an IExternalResourceServer to override the path that is used within this Revit
 session to display and browse to a specific ExternalResourceReference. This method is provided
 to accommodate IExternalResourceServers that may present different paths under different circumstances.
 For example, an IExternalResourceServer might implement this method to return a display path
 that uses the appropriate language for the user's current locale. An IExternalResourceServer
 could also use this method to present the appropriate name if the user has renamed this
 resource since the last time it was loaded. If the IExternalResourceServer does not need to
 customize the display path, it can return the originalDisplayPath parameter.
Revit will invoke this method when the model is first loaded or before calling LoadResource(Guid, ExternalResourceType, ExternalResourceReference, ExternalResourceLoadContext, ExternalResourceLoadContent) 
 and cache the result in the ExternalResourceReference. Do not rely on this path to look up an ExternalResourceReference, as the path is neither unique nor stable. It isn't unique
 because multiple servers might use the same server name and display name format. It isn't stable because some servers allow renaming,
 and because a server might change its name at some point.

