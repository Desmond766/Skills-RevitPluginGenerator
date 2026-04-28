---
kind: method
id: M:Autodesk.Revit.DB.SpecUtils.IsValidDataType(Autodesk.Revit.DB.ForgeTypeId)
source: html/cd553ad7-4af2-c270-45b9-7ebc49b50a6d.htm
---
# Autodesk.Revit.DB.SpecUtils.IsValidDataType Method

Returns true if the given ForgeTypeId identifies a valid parameter data type.

## Syntax (C#)
```csharp
public static bool IsValidDataType(
	ForgeTypeId dataType
)
```

## Parameters
- **dataType** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier to check.

## Returns
True if the ForgeTypeId identifies either a spec or a category, false otherwise.

## Remarks
A ForgeTypeId is acceptable as a parameter data type if it
 identifies either a spec or a category. When a category
 identifier is used as a parameter data type, it indicates a
 Family Type parameter of that category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

