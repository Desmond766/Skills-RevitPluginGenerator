---
kind: method
id: M:Autodesk.Revit.DB.Categories.NewSubcategory(Autodesk.Revit.DB.Category,System.String)
source: html/aba44eba-9882-54cb-fe52-30553a684c34.htm
---
# Autodesk.Revit.DB.Categories.NewSubcategory Method

Add a new subcategory into the Autodesk Revit document.

## Syntax (C#)
```csharp
public Category NewSubcategory(
	Category parentCategory,
	string name
)
```

## Parameters
- **parentCategory** (`Autodesk.Revit.DB.Category`) - The parent category.
- **name** (`System.String`) - The new category name.

## Returns
If successful, the newly created subcategory.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"parentCategory" or "name"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"parentCategory"-cannot add subcategory.
Thrown when the input argument-"name"-is an illegal name.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when subcategory creation failed.

