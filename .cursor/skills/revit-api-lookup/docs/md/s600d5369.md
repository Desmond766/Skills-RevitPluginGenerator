---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipingSystemType.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.MEPSystemClassification,System.String)
zh: 创建、新建、生成、建立、新增
source: html/046cbcbc-bf76-4a77-672b-0da66b906963.htm
---
# Autodesk.Revit.DB.Plumbing.PipingSystemType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a piping system type and adds it to the document.

## Syntax (C#)
```csharp
public static PipingSystemType Create(
	Document ADoc,
	MEPSystemClassification systemClassification,
	string name
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The document where the element will be created and added.
- **systemClassification** (`Autodesk.Revit.DB.MEPSystemClassification`) - The classification for the piping system type to be created
- **name** (`System.String`) - The name of the piping system type to be created.

## Returns
The newly created piping system type element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The system classification is not valid for the domain of this system type.

