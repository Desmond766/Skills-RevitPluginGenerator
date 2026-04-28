---
kind: method
id: M:Autodesk.Revit.DB.Structure.LoadCase.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.LoadCaseCategory)
zh: 创建、新建、生成、建立、新增
source: html/5af8b8cf-b9bc-bbc6-76e3-87539afab783.htm
---
# Autodesk.Revit.DB.Structure.LoadCase.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new LoadCase.

## Syntax (C#)
```csharp
public static LoadCase Create(
	Document document,
	string name,
	ElementId natureId,
	LoadCaseCategory loadCaseCategory
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document to which new load case element will be added.
- **name** (`System.String`) - The name of the load case.
- **natureId** (`Autodesk.Revit.DB.ElementId`) - The load nature ID.
- **loadCaseCategory** (`Autodesk.Revit.DB.Structure.LoadCaseCategory`) - The predefined load case category.

## Returns
The newly created load case element if successful, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Remarks
This method is designed to create LoadCase that is associated with one of the predefined category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given name is not unique.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

