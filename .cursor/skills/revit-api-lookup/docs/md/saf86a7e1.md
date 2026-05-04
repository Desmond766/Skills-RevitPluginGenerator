---
kind: method
id: M:Autodesk.Revit.DB.Analysis.GenericZone.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.Analysis.GenericZoneDomainData,Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
zh: 创建、新建、生成、建立、新增
source: html/2af51757-c003-cd4f-25de-82e0d5964824.htm
---
# Autodesk.Revit.DB.Analysis.GenericZone.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a generic zone and adds it to the document.

## Syntax (C#)
```csharp
public static GenericZone Create(
	Document doc,
	string name,
	GenericZoneDomainData domainData,
	ElementId levelId,
	IList<CurveLoop> curveLoops
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document where the element will be created and added.
- **name** (`System.String`) - The name of the generic zone to be created.
- **domainData** (`Autodesk.Revit.DB.Analysis.GenericZoneDomainData`) - The specific domain requirements for the generic zone.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The base level on which the generic zone will be created.
- **curveLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The loops that define the lines, curves and areas that overlap or crosses the elements you want to belong to the zone.
 Multiple loops are allowed, they can be open or closed, but they should be on the same horizontal plane.

## Returns
The newly created generic zone.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 name is an empty string.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The curve loops in the input array are empty.
 -or-
 The input curve loops do not all lie in the same horizontal plane.
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

