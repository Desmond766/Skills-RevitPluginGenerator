---
kind: method
id: M:Autodesk.Revit.DB.LinkLoadResult.GetExternalResourceReferencesFromFailedLoads
source: html/c80085bc-0123-6dc6-69ab-9cc2510d33d2.htm
---
# Autodesk.Revit.DB.LinkLoadResult.GetExternalResourceReferencesFromFailedLoads Method

Searches this and all nested LinkLoadResults, and returns a list
 of ExternalResourceReferences for the links that failed to load.

## Syntax (C#)
```csharp
public IList<ExternalResourceReference> GetExternalResourceReferencesFromFailedLoads()
```

## Returns
A collection of link ExternalResourceReferences which failed to load.

## Remarks
In cases, where a nested structure of several links were loaded, this
 method is intended to be a convenient way for IExternalResourceUIServers to
 determine whether a top-level link, or any sub-link, which failed to load
 properly was provided by their IExternalResourceServer or another server. If this link and all nested links loaded successfully, then an empty list is returned.

