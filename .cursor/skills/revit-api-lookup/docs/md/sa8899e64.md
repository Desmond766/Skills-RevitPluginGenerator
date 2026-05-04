---
kind: property
id: P:Autodesk.Revit.DB.ExternalResourceReference.InSessionPath
source: html/8f8d1ee6-26e4-fbad-b000-709cdc6df801.htm
---
# Autodesk.Revit.DB.ExternalResourceReference.InSessionPath Property

The path stores the full display path which includes the server name plus the path provided by ExternalResourceServer. The path that Revit will present for user recognizing and browsing to this resource during one session of Revit. This property allows ExternalResourceServers to handle cases where the path to a resource may vary between Revit sessions.
 For example, if this ExternalResourceReference refers to a resource in a folder,
 this property can be used to store the current path of the resource. If the resource is moved to another folder later,
 the ExternalResourceServer could calculate the correct path for the resource from resource identification information
 when it is loaded and store it in this property,
 so that it will work correctly even if the rvt file is opened in a different location. Do not rely on this path to look up an ExternalResourceReference, as the path is neither unique nor stable. It isn't unique
 because multiple servers might use the same server name and display name format. It isn't stable because some servers allow renaming,
 and because a server might change its name at some point.

## Syntax (C#)
```csharp
public string InSessionPath { get; internal set; }
```

