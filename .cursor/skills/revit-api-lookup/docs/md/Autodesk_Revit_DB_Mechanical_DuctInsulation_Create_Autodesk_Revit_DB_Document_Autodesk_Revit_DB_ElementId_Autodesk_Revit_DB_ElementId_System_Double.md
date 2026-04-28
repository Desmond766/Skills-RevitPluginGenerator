---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.DuctInsulation.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/2b56ea02-1c59-5704-7d9e-ebf9fd4a80d4.htm
---
# Autodesk.Revit.DB.Mechanical.DuctInsulation.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of duct insulation.

## Syntax (C#)
```csharp
public static DuctInsulation Create(
	Document document,
	ElementId ductOrContentElementId,
	ElementId ductInsulationTypeId,
	double Thickness
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **ductOrContentElementId** (`Autodesk.Revit.DB.ElementId`) - The duct , fitting or accessory ElementId to which insulation will be added.
- **ductInsulationTypeId** (`Autodesk.Revit.DB.ElementId`) - The duct insulation type.
 If the input duct insulation type is InvalidElementId, the default insulation type from the document will be used.
- **Thickness** (`System.Double`) - The thickness of the insulation.

## Returns
The newly created duct insulation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This id does not represent a duct, fitting, or accessory element.
 -or-
 This duct insulation type is invalid.
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

