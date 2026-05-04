---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelForDiscipline(Autodesk.Revit.DB.ForgeTypeId)
source: html/09ff409c-3deb-3bd8-d2ef-7eab4fbe4973.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelForDiscipline Method

Gets the user-visible name for a discipline.

## Syntax (C#)
```csharp
public static string GetLabelForDiscipline(
	ForgeTypeId disciplineTypeId
)
```

## Parameters
- **disciplineTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the discipline.

## Remarks
The name is obtained in the current Revit language.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Discipline must have a definition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

