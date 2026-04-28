---
kind: method
id: M:Autodesk.Revit.DB.Category.IsBuiltInCategoryValid(Autodesk.Revit.DB.BuiltInCategory)
source: html/15f903ae-3cdf-52b0-4891-fa2d1002e481.htm
---
# Autodesk.Revit.DB.Category.IsBuiltInCategoryValid Method

Checks if a Category exists for a given BuiltInCategory.

## Syntax (C#)
```csharp
public static bool IsBuiltInCategoryValid(
	BuiltInCategory builtInCategory
)
```

## Parameters
- **builtInCategory** (`Autodesk.Revit.DB.BuiltInCategory`) - The BuiltInCategory to check.

## Remarks
Some BuiltInCategory values are obsolete and are kept for upgrade reasons. For those no Category exists.

