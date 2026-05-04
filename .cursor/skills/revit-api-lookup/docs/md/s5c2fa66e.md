---
kind: method
id: M:Autodesk.Revit.DB.Structure.LoadCase.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/104af293-89a0-b8c0-4d5c-740ec2bda582.htm
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
	ElementId subcategoryId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document to which new load case element will be added.
- **name** (`System.String`) - The name of the load case.
- **natureId** (`Autodesk.Revit.DB.ElementId`) - The load nature ID.
- **subcategoryId** (`Autodesk.Revit.DB.ElementId`) - The load case subcategory ID. Could be one of predefined or user defined load case category.
 Built-in structural Load Cases ( OST_LoadCases ) subcategories are:
 OST_LoadCasesDead OST_LoadCasesLive OST_LoadCasesWind OST_LoadCasesSnow OST_LoadCasesRoofLive OST_LoadCasesAccidental OST_LoadCasesTemperature OST_LoadCasesSeismic

## Returns
The newly created load case element if successful, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Remarks
This method is designed to create LoadCase that is associated with user defined category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given name is not unique.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

