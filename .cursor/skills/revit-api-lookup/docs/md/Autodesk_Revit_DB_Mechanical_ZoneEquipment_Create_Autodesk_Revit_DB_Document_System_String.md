---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.ZoneEquipment.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/35301c04-14f5-16b9-729b-677158843a3a.htm
---
# Autodesk.Revit.DB.Mechanical.ZoneEquipment.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new zone equipment

## Syntax (C#)
```csharp
public static ZoneEquipment Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the new element will be created.
- **name** (`System.String`) - The name of new zone equipment. The actual name may be post-fixed if already exists.

## Returns
The newly created zone equipment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 name is an empty string.
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

