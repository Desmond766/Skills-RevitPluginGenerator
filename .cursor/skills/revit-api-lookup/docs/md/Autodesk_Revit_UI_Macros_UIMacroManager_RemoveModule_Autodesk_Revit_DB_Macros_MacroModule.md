---
kind: method
id: M:Autodesk.Revit.UI.Macros.UIMacroManager.RemoveModule(Autodesk.Revit.DB.Macros.MacroModule)
source: html/805e9c82-6deb-0d55-d357-5ac5ae6ef544.htm
---
# Autodesk.Revit.UI.Macros.UIMacroManager.RemoveModule Method

Removes a MacroModule from the application or document.

## Syntax (C#)
```csharp
public void RemoveModule(
	MacroModule module
)
```

## Parameters
- **module** (`Autodesk.Revit.DB.Macros.MacroModule`) - The module will be removed.

## Remarks
Note: document-level modules will not be removed to the document until the document is saved.
 Thus this operation is not undoable and does not require an open transaction even for document-level modules.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

