---
kind: method
id: M:Autodesk.Revit.UI.Macros.UIMacroManager.AddModule(Autodesk.Revit.DB.Macros.ModuleSettings,Autodesk.Revit.DB.Macros.MacroEnvironment)
source: html/afa00228-ce55-565b-3c73-7541cd3e3df2.htm
---
# Autodesk.Revit.UI.Macros.UIMacroManager.AddModule Method

Adds a MacroModule to the application or document.

## Syntax (C#)
```csharp
public MacroModule AddModule(
	ModuleSettings moduleSettings,
	MacroEnvironment environment
)
```

## Parameters
- **moduleSettings** (`Autodesk.Revit.DB.Macros.ModuleSettings`) - The module settings.
- **environment** (`Autodesk.Revit.DB.Macros.MacroEnvironment`) - The module environment.

## Returns
The new module.

## Remarks
Note: document-level modules will not be saved to the document until the document is saved.
 Thus this operation is not undoable and does not require an open transaction even for document-level modules.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the module name is duplicated with the existing one,
 or the name is too long, or the name contains invalid identifier(s),
 such as include "#", "%", ... and key words in C# or VB.NET.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

