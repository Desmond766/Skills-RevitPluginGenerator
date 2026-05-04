---
kind: method
id: M:Autodesk.Revit.DB.Category.GetBuiltInCategory(Autodesk.Revit.DB.ForgeTypeId)
source: html/7aa968aa-3c15-7937-c1e7-a899e35b4ee7.htm
---
# Autodesk.Revit.DB.Category.GetBuiltInCategory Method

Gets the BuiltInCategory value corresponding to the given built-in category identifier.

## Syntax (C#)
```csharp
public static BuiltInCategory GetBuiltInCategory(
	ForgeTypeId categoryTypeId
)
```

## Parameters
- **categoryTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The built-in category identifier.

## Returns
The BuiltInCategory value corresponding to the given built-in category identifier.

## Remarks
A ForgeTypeId identifies a built-in category if it corresponds to a valid
 BuiltInCategory value according to
 Category.IsBuiltInCategory(ForgeTypeId) and
 Category.GetBuiltInCategoryTypeId(BuiltInCategory) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - categoryTypeId is not a built-in category identifier. See Category.IsBuiltInCategory(ForgeTypeId) and Category.GetBuiltInCategoryTypeId(BuiltInCategory).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

