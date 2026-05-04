---
kind: method
id: M:Autodesk.Revit.DB.Category.GetBuiltInCategoryTypeId(Autodesk.Revit.DB.BuiltInCategory)
source: html/957321bd-0fea-ccc5-3fbb-f461df557f8d.htm
---
# Autodesk.Revit.DB.Category.GetBuiltInCategoryTypeId Method

Gets the ForgeTypeId identifying the given built-in category.

## Syntax (C#)
```csharp
public static ForgeTypeId GetBuiltInCategoryTypeId(
	BuiltInCategory categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.BuiltInCategory`) - The built-in category.

## Returns
The identifier of the given built-in category.

## Remarks
The given BuiltInCategory value must be valid according to
 Category.IsBuiltInCategoryValid(BuiltInCategory) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - categoryId is not a valid built-in category. See Category.IsBuiltInCategoryValid(BuiltInCategory).

