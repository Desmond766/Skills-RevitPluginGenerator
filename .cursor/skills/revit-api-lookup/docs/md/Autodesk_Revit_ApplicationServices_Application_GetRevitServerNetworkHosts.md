---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.GetRevitServerNetworkHosts
source: html/991a3eaa-91ea-78bf-86cc-a45a92ff4e08.htm
---
# Autodesk.Revit.ApplicationServices.Application.GetRevitServerNetworkHosts Method

Gets the list of all Revit Server Network hosts in current session.

## Syntax (C#)
```csharp
public IList<string> GetRevitServerNetworkHosts()
```

## Returns
An array of names of all Revit Server Network hosts in current session.

## Remarks
The list of Revit Server Network hosts is stored externally in the RSN[version].ini file.

