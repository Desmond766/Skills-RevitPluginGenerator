---
kind: method
id: M:Autodesk.Revit.DB.Macros.MacroManager.SetDocumentMacroSecurityOptions(Autodesk.Revit.ApplicationServices.Application,Autodesk.Revit.DB.Macros.DocumentMacroOptions)
source: html/df7cf42d-8613-1d41-7d0c-182b2f9588cd.htm
---
# Autodesk.Revit.DB.Macros.MacroManager.SetDocumentMacroSecurityOptions Method

Sets the document macro security options.

## Syntax (C#)
```csharp
public static void SetDocumentMacroSecurityOptions(
	Application application,
	DocumentMacroOptions macroOptions
)
```

## Parameters
- **application** (`Autodesk.Revit.ApplicationServices.Application`) - The application.
- **macroOptions** (`Autodesk.Revit.DB.Macros.DocumentMacroOptions`) - The document macro security options.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

