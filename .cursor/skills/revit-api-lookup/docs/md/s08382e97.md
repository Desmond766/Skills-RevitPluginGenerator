---
kind: method
id: M:Autodesk.Revit.DB.Macros.MacroManager.AddModule(Autodesk.Revit.DB.Macros.ModuleSettings)
source: html/66ea5747-0492-62d8-8869-5a2455977348.htm
---
# Autodesk.Revit.DB.Macros.MacroManager.AddModule Method

Adds a MacroModule to the application or document.

## Syntax (C#)
```csharp
public MacroModule AddModule(
	ModuleSettings moduleSettings
)
```

## Parameters
- **moduleSettings** (`Autodesk.Revit.DB.Macros.ModuleSettings`) - The module settings.

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

