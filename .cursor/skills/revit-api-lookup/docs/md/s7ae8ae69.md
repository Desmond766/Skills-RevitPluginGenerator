---
kind: method
id: M:Autodesk.Revit.DB.Category.IsBuiltInCategory(Autodesk.Revit.DB.ForgeTypeId)
source: html/efbd8409-b82b-11d8-4b20-65ffc27b750e.htm
---
# Autodesk.Revit.DB.Category.IsBuiltInCategory Method

Checks whether a ForgeTypeId identifies a built-in category.

## Syntax (C#)
```csharp
public static bool IsBuiltInCategory(
	ForgeTypeId categoryTypeId
)
```

## Parameters
- **categoryTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier to check.

## Returns
True if the ForgeTypeId identifies a built-in category, false otherwise.

## Remarks
A ForgeTypeId identifies a built-in category if it corresponds to a valid
 BuiltInCategory value according to
 Category.IsBuiltInCategoryValid(BuiltInCategory) and
 Category.GetBuiltInCategoryTypeId(BuiltInCategory) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

