---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSet.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
zh: 创建、新建、生成、建立、新增
source: html/6635ff73-f561-756b-1bf9-4d6c18b1a1af.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSet.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a mechanical equipment set and adds it to the document.

## Syntax (C#)
```csharp
public static MechanicalEquipmentSet Create(
	Document document,
	ElementId typeId,
	ISet<ElementId> memberIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the element will be created and added.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The type of new mechanical equipment set.
- **memberIds** (`System.Collections.Generic.ISet < ElementId >`) - The member elements of this mechanical equipment set.

## Returns
The newly created mechanical equipment set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Invalid mechanical equipment set type.
 -or-
 This mechanical equipment set needs at least two members.
 -or-
 The valid members must have the same classification and system. A valid member cannot be a member of any other existing set.
 -or-
 These elements are serially connected.
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

