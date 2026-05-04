---
kind: method
id: M:Autodesk.Revit.UI.IExternalResourceUIServer.HandleBrowseResult(Autodesk.Revit.DB.ExternalResourceUIBrowseResultType,System.String)
source: html/7a1805d4-0142-5162-4507-882ab705ab01.htm
---
# Autodesk.Revit.UI.IExternalResourceUIServer.HandleBrowseResult Method

Implement this method to handle results from browsing external resources
 in the UI. It is recommended that the server only respond in the case of a critical error.

## Syntax (C#)
```csharp
void HandleBrowseResult(
	ExternalResourceUIBrowseResultType resultType,
	string browsingItemPath
)
```

## Parameters
- **resultType** (`Autodesk.Revit.DB.ExternalResourceUIBrowseResultType`) - The result of the browsing operation.
- **browsingItemPath** (`System.String`) - The absolute path of the current item being browsed.

## Remarks
This method will be called automatically when the user browses for external resources,
 such as listing folders and resources of an external server or a subfolder,
 or choosing an external resource in the add resource dialog.

