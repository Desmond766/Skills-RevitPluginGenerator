---
kind: method
id: M:Autodesk.Revit.DB.DisplacementPath.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.DisplacementElement,Autodesk.Revit.DB.Reference,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/c3a023a5-b875-4de1-a092-f62002a258cf.htm
---
# Autodesk.Revit.DB.DisplacementPath.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new DisplacementPath referencing a DisplacementElement and edge or curve and adds it to the document.

## Syntax (C#)
```csharp
public static ElementId Create(
	Document aDoc,
	DisplacementElement displacementElement,
	Reference reference,
	double param
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.
- **displacementElement** (`Autodesk.Revit.DB.DisplacementElement`) - Element id of a DisplacementElement
- **reference** (`Autodesk.Revit.DB.Reference`) - A reference that refers to an edge or curve of one of the elements displaced by the displacementElement.
- **param** (`System.Double`) - A value in the range [0,1]. It will be interpreted as a parameter for the specified edge.

## Returns
The element id of the newly created DisplacementPath.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The value param should lie in the range [0,1].
 -or-
 reference does not represent an edge or curve belonging to an element displaced by displacementElement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

