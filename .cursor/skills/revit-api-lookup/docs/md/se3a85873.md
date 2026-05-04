---
kind: method
id: M:Autodesk.Revit.DB.Macros.MacroManager.SetApplicationMacroSecurityOptions(Autodesk.Revit.ApplicationServices.Application,Autodesk.Revit.DB.Macros.ApplicationMacroOptions)
source: html/0adef94d-9b9f-4409-d543-c023c0041301.htm
---
# Autodesk.Revit.DB.Macros.MacroManager.SetApplicationMacroSecurityOptions Method

Sets the application macro security options.

## Syntax (C#)
```csharp
public static void SetApplicationMacroSecurityOptions(
	Application application,
	ApplicationMacroOptions macroOptions
)
```

## Parameters
- **application** (`Autodesk.Revit.ApplicationServices.Application`) - The application.
- **macroOptions** (`Autodesk.Revit.DB.Macros.ApplicationMacroOptions`) - The application macro security options.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

