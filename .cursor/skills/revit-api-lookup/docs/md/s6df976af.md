---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.DuctLining.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/06c3896c-ba5f-b783-0aa9-a6d3d3bf51f3.htm
---
# Autodesk.Revit.DB.Mechanical.DuctLining.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of duct lining.

## Syntax (C#)
```csharp
public static DuctLining Create(
	Document document,
	ElementId ductOrContentElementId,
	ElementId ductLiningTypeId,
	double Thickness
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **ductOrContentElementId** (`Autodesk.Revit.DB.ElementId`) - The duct, fitting or accessory ElementId to which lining will be added.
- **ductLiningTypeId** (`Autodesk.Revit.DB.ElementId`) - The duct lining type.
 If the input duct lining type is InvalidElementId, the default lining type from the document will be used.
- **Thickness** (`System.Double`) - The thickness of the lining.

## Returns
The newly created duct lining.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This id does not represent a duct, fitting, or accessory element.
 -or-
 This duct Lining type is invalid.
 -or-
 Thickness is not valid for assignment to insulation or lining elements.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
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

