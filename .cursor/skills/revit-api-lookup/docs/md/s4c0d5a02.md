---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.ConvertToRealSheet(Autodesk.Revit.DB.ElementId)
zh: 图纸
source: html/cfd7f789-41cf-1e86-a757-fe4ff5d8ba89.htm
---
# Autodesk.Revit.DB.ViewSheet.ConvertToRealSheet Method

**中文**: 图纸

Converts a placeholder sheet to a real one with an optional titleblock.

## Syntax (C#)
```csharp
public void ConvertToRealSheet(
	ElementId titleBlockTypeId
)
```

## Parameters
- **titleBlockTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the placeholder sheet, or invalidElementId if no titleblock should be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - titleBlockTypeId does not correspond to a TitleBlock type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This method may only be called on a placeholder sheet.
 -or-
 Failed to convert the sheet because the input titleblock could not be applied.

