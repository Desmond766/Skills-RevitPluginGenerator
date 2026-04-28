---
kind: method
id: M:Autodesk.Revit.DB.TemporaryViewModes.GetCaption(Autodesk.Revit.DB.TemporaryViewMode)
source: html/832c859a-4a42-4c2b-8a78-6b15d60f8773.htm
---
# Autodesk.Revit.DB.TemporaryViewModes.GetCaption Method

A text caption to use for the given mode.

## Syntax (C#)
```csharp
public string GetCaption(
	TemporaryViewMode mode
)
```

## Parameters
- **mode** (`Autodesk.Revit.DB.TemporaryViewMode`) - The mode to get a caption for.

## Returns
Text of the caption. The text is localized.

## Remarks
The text appears in the UI on the temporary frame when the view is in the temporary mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

