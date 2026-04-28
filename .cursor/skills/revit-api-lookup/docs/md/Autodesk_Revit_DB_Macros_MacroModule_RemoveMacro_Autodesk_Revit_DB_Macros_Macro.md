---
kind: method
id: M:Autodesk.Revit.DB.Macros.MacroModule.RemoveMacro(Autodesk.Revit.DB.Macros.Macro)
source: html/66e8c11a-60fc-3046-de82-55020a2ceb3f.htm
---
# Autodesk.Revit.DB.Macros.MacroModule.RemoveMacro Method

Removes a macro from the module.

## Syntax (C#)
```csharp
public void RemoveMacro(
	Macro macro
)
```

## Parameters
- **macro** (`Autodesk.Revit.DB.Macros.Macro`) - The macro will be removed from this module.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot remove the Macro due to no permission.

