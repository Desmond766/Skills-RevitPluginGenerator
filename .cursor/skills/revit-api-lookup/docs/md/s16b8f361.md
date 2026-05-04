---
kind: method
id: M:Autodesk.Revit.DB.IExternalResourceServer.SetupBrowserData(Autodesk.Revit.DB.ExternalResourceBrowserData)
source: html/04e7642f-aea8-7996-4f3b-6b5e8834a1f9.htm
---
# Autodesk.Revit.DB.IExternalResourceServer.SetupBrowserData Method

Implement this method to setup external resource browser data which will be accessed in Revit external resource browser UI.

## Syntax (C#)
```csharp
void SetupBrowserData(
	ExternalResourceBrowserData browseData
)
```

## Parameters
- **browseData** (`Autodesk.Revit.DB.ExternalResourceBrowserData`) - The input context to match the external resources and browser results returned by the server.

## Remarks
If errors occur during setup, store this information externally, and then retrieve and deal
 with the errors during the call to HandleBrowseResult() of your IExternalResourceUIServer.

