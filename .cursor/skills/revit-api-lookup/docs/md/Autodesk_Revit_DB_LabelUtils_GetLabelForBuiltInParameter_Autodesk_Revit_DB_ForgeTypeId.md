---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelForBuiltInParameter(Autodesk.Revit.DB.ForgeTypeId)
source: html/482c49db-8994-bcc8-3077-02d8f40ba3db.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelForBuiltInParameter Method

Gets the user-visible name for a built-in parameter.

## Syntax (C#)
```csharp
public static string GetLabelForBuiltInParameter(
	ForgeTypeId parameterTypeId
)
```

## Parameters
- **parameterTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the built-in parameter to get the user-visible name.

## Remarks
The name is obtained in the current Revit language.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the built-in parameter cannot be found.

