---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSetType.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/74330acb-c529-5add-44b8-0ec564282c0e.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSetType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new type of a mechanical equipment set and adds it to the document.

## Syntax (C#)
```csharp
public static MechanicalEquipmentSetType Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the new type is created.
- **name** (`System.String`) - The name of new type.

## Returns
The newly created mechanical equipment set type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 name is an empty string.
 -or-
 The given name is not unique
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

