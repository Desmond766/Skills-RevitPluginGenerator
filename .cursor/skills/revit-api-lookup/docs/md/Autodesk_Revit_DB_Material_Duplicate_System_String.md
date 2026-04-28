---
kind: method
id: M:Autodesk.Revit.DB.Material.Duplicate(System.String)
zh: 材质、材料
source: html/683b9b3b-fcd7-299d-e42f-712ac1550f17.htm
---
# Autodesk.Revit.DB.Material.Duplicate Method

**中文**: 材质、材料

Duplicates the material

## Syntax (C#)
```csharp
public Material Duplicate(
	string name
)
```

## Parameters
- **name** (`System.String`) - Name of the new material - this name must be correctly structured for Revit use and not duplicate the name
 of another material in the document.

## Returns
The new material.

## Remarks
If duplication fails for reasons unrelated to the name, Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given value for name is already in use as a material element name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

