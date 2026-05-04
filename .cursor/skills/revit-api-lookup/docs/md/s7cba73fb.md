---
kind: property
id: P:Autodesk.Revit.DB.Family.FamilyCategory
zh: 族
source: html/e00c2b8b-b92d-526b-11b6-71c7e1d5d1b7.htm
---
# Autodesk.Revit.DB.Family.FamilyCategory Property

**中文**: 族

Retrieves or sets a Category object that represents the category or sub category in which the elements
( this family could generate ) reside.

## Syntax (C#)
```csharp
public Category FamilyCategory { get; set; }
```

## Remarks
All category objects can be retrieved from the application by using the Categories property
of the Application.Settings object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input category cannot be assigned to this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input category is Nothing nullptr a null reference ( Nothing in Visual Basic) .

