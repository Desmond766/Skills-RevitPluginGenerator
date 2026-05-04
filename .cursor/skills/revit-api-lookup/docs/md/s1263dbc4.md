---
kind: method
id: M:Autodesk.Revit.UI.Macros.UIMacroManager.StepInto(Autodesk.Revit.DB.Macros.Macro)
source: html/0d363225-68f3-20e1-eb3f-30cfdbc575c3.htm
---
# Autodesk.Revit.UI.Macros.UIMacroManager.StepInto Method

Step into the macro in sharp develop.

## Syntax (C#)
```csharp
public void StepInto(
	Macro macro
)
```

## Parameters
- **macro** (`Autodesk.Revit.DB.Macros.Macro`) - The macro.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Throw when the module is unloaded, or it is a Ruby or Python script.

