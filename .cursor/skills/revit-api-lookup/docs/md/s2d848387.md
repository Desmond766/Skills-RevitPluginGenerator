---
kind: method
id: M:Autodesk.Revit.DB.Macros.MacroManager.RemoveModule(Autodesk.Revit.DB.Macros.MacroModule)
source: html/c22a452e-578c-d468-e041-e70fd72cc78f.htm
---
# Autodesk.Revit.DB.Macros.MacroManager.RemoveModule Method

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
- **Autodesk.Revit.Exceptions.ArgumentException** - The given module is not a member of this collection.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the given module is a UI module.

